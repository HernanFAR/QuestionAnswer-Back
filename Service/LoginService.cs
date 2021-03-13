using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Service.Exceptions;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DA = System.ComponentModel.DataAnnotations;
using Fluent = FluentValidation;

namespace Service
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<QuestionAnswerUser> _UserManager;
        private readonly SignInManager<QuestionAnswerUser> _SignInManager;
        private readonly IConfiguration _Configuration;
        private readonly IMailService _MailService;
        private readonly IUrlCreator _UrlCreator;
        private readonly ILogger _Logger;

        public LoginService(UserManager<QuestionAnswerUser> userManager, SignInManager<QuestionAnswerUser> signInManager,
            IConfiguration configuration, IMailService mailService, IUrlCreator urlCreator, ILogger logger)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _Configuration = configuration;
            _MailService = mailService;
            _UrlCreator = urlCreator;
            _Logger = logger;
        }

        public async Task UpdateInformation(ChangeInformation model)
        {
            ValidateObjectBeforeCreating(model);

            var user = await FindByEmail(model.OriginalEmail);

            if (user.Id != model.IdEntity)
                throw new InvalidOperationException(nameof(user.Id));

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;

            if (model.Email != model.OriginalEmail)
                user.EmailConfirmed = false;

            ThrowIdentityErrorIfNotValid(await _UserManager.UpdateAsync(user));

            await _UserManager.UpdateNormalizedEmailAsync(user);
            await _UserManager.UpdateNormalizedUserNameAsync(user);

            if (!user.EmailConfirmed)
                await SendConfirmEmail(model.Email);
        }

        public async Task ConfirmEmail(ConfirmEmailData model)
        {
            ValidateObjectBeforeCreating(model);

            var user = await FindById(model.UserId);

            byte[] decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            ThrowIdentityErrorIfNotValid(await _UserManager.ConfirmEmailAsync(user, normalToken));
        }

        public async Task DeleteUser(string userId)
        {
            var user = await FindById(userId);

            ThrowIdentityErrorIfNotValid(await _UserManager.DeleteAsync(user));
        }

        public async Task ForgetPassword(string email)
        {
            var user = await FindByEmail(email);

            string token = await _UserManager.GeneratePasswordResetTokenAsync(user);
            string resetToken = EncodeToken(token);
            string url = $"{_UrlCreator.GetUrl()}/changePassword?email={email}&token={resetToken}";

            string content = String.Empty;
            
            content = string.Concat(content, "<h3>Bienvenido a la Portal los castaños.</h3>");
            content = string.Concat(content, "<p>Se ha solicitado un cambio de contraseña en tu cuenta, ");
            content = string.Concat(content, "si tu no realizaste esta accion, por favor, ignora este correo.");
            content = string.Concat(content, "<br />");
            content = string.Concat(content, $"Enlace a la pagina: <a href={url}>Aqui</a></p>");
            content = string.Concat(content, "<br />");
            content = string.Concat(content, "<p>Que tenga un grato dia.</p>");

            EmailInformation emailInformation = new EmailInformation
            {
                Tos = new List<string> { user.Email },
                Copies = new List<string>(),
                Subject = "Cambio de consetraseña",
                Content = content
            };

            await _MailService.SendEmail(emailInformation);
        }

        public async Task<TokenData> LoginUser(LoginSession model)
        {
            ValidateObjectBeforeCreating(model);

            // Busqueda de ellos en la base de datos
            var user = await FindByEmail(model.Email);

            bool canSignIn = await _SignInManager.CanSignInAsync(user);

            if (!canSignIn)
                throw new InvalidOperationException(nameof(canSignIn));

            SignInResult result = await _SignInManager.PasswordSignInAsync(user, model.Password, true, true);

            await ManageSignInResult(result, user.Id);

            TokenData tokenData = CreateJwtToken(user); ;

            string content = String.Empty;
            string url = _UrlCreator.GetUrl() + "/forgetPassword";

            content = string.Concat(content, "<h3>Bienvenido a la Portal los castaños.</h3>");
            content = string.Concat(content, "<p>Se ha detectado un nuevo inicio de sesion en tu cuenta, a las " + DateTime.Now);
            content = string.Concat(content, " si tu no realizaste esta accion, por favor, cambia inmediatamente la contraseña");
            content = string.Concat(content, $" de tu cuenta de Portal los castaños, mediante este <a href='{url}'>link</a>.</p>");
            content = string.Concat(content, "<br />");
            content = string.Concat(content, "<p>Que tenga un grato dia.</p>");

            EmailInformation emailInformation = new EmailInformation
            {
                Tos = new List<string> { model.Email },
                Subject = "Nuevo inicio de sesion",
                Content = content
            };

            try
            {
                await _MailService.SendEmail(emailInformation);
            }
            catch { }

            return tokenData;
        }

        public async Task<UserCreated> RegisterUser(RegisterData model)
        {
            ValidateObjectBeforeCreating(model);

            var user = new QuestionAnswerUser { 
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };

            ThrowIdentityErrorIfNotValid(await _UserManager.CreateAsync(user, model.Password));

            bool emailSended = false;

            try
            {
                await SendConfirmEmail(model.Email);
                emailSended = true;
            }
            catch { }

            return new UserCreated
            {
                IdEntity = user.Id,
                EmailSended = emailSended
            };
        }

        public async Task ResetPassword(ResetPassword model)
        {
            ValidateObjectBeforeCreating(model);

            var user = await FindByEmail(model.Email);

            string normalToken = DecodeToken(model.Token);

            ThrowIdentityErrorIfNotValid(await _UserManager.ResetPasswordAsync(user, normalToken, model.Password));
        }

        public async Task SendConfirmEmail(string email)
        {
            var user = await FindByEmail(email);

            string token = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
            string emailToken = EncodeToken(token);
            string url = $"{_UrlCreator.GetUrl()}/confirmEmail?token={emailToken}";

            string content = String.Empty;

            content = string.Concat(content, "<h3>Bienvenido a la Portal los castaños.</h3>");
            content = string.Concat(content, "<p>Se ha realizado una confirmacion de correo en tu cuenta</p>");
            content = string.Concat(content, "<br />");
            content = string.Concat(content, $"Haz click aca para confirmar tu correo: <a href={url}>Aqui</a></p>");
            content = string.Concat(content, "<br />");
            content = string.Concat(content, "<p>Que tenga un grato dia.</p>");

            EmailInformation emailInformation = new EmailInformation
            {
                Tos = new List<string> { user.Email },
                Subject = "Confirma tu correo electronico",
                Copies = new List<string>(),
                Content = content
            };

            await _MailService.SendEmail(emailInformation);
        }

        public async Task<QuestionAnswerUser> FindByEmail(string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);

            if (user == null)
                throw new InvalidOperationException(nameof(user));

            return user;
        }

        public async Task<QuestionAnswerUser> FindById(string id)
        {
            var user = await _UserManager.FindByIdAsync(id);

            if (user == null)
                throw new InvalidOperationException(nameof(user));

            return user;
        }

        private static void ThrowIdentityErrorIfNotValid(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                List<ValidationFailure> validationFailures = new List<ValidationFailure>();

                result.Errors.ToList().ForEach(e =>
                    validationFailures.Add(
                        new ValidationFailure(
                            string.Join(", ", e.Code),
                            e.Description
                        )
                    )
                );

                throw new Fluent.ValidationException(validationFailures);
            }
        }

        private static string EncodeToken(string token)
        {
            byte[] encodedResetToken = Encoding.UTF8.GetBytes(token);
            string encodedToken = WebEncoders.Base64UrlEncode(encodedResetToken);

            return encodedToken;
        }

        private static string DecodeToken(string token)
        {
            byte[] decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            return normalToken;
        }

        private TokenData CreateJwtToken(QuestionAnswerUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Id)
            };


            JwtConfiguration jwtConfiguration = new JwtConfiguration();

            _Configuration.GetSection("JwtAuthentication").Bind(jwtConfiguration);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.IssuerSigningKey));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtConfiguration.Issuer,
                audience: jwtConfiguration.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwtConfiguration.Duration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenData
            {
                Token = tokenHandler.WriteToken(token),
                ExpireDate = token.ValidTo
            };
        }

        private async Task ManageSignInResult(SignInResult result, string userId)
        {
            if (result.IsLockedOut)
            {
                var user = await FindById(userId);

                throw new LockedUserException(user.LockoutEnd.Value);
            }

            if (result.IsNotAllowed)
                throw new InvalidOperationException(nameof(result.IsNotAllowed));

            if (!result.Succeeded)
            {
                var user = await FindById(userId);

                throw new WrongPasswordException(user.AccessFailedCount, 5);
            }
        }

        private void ValidateObjectBeforeCreating(object entity)
        {
            var context = new DA.ValidationContext(entity);
            List<DA.ValidationResult> errors = new List<DA.ValidationResult>();

            var isValid = DA.Validator.TryValidateObject(entity, context, errors, true);

            if (isValid)
                return;

            LogIfNotNull(LogLevel.Warning,
                $"La entidad no es valida"
            );

            List<ValidationFailure> validationFailures = new List<ValidationFailure>();

            errors.ForEach(e =>
                validationFailures.Add(
                    new ValidationFailure(
                        string.Join(", ", e.MemberNames),
                        e.ErrorMessage
                    )
                )
            );

            throw new Fluent.ValidationException(validationFailures);
        }

        private void LogIfNotNull(LogLevel level, string loggerMessage)
        {
            if (_Logger != null)
            {
                switch (level)
                {
                    case LogLevel.Trace:
                        _Logger.LogTrace(loggerMessage);
                        break;

                    case LogLevel.Debug:
                        _Logger.LogDebug(loggerMessage);
                        break;

                    case LogLevel.Information:
                        _Logger.LogInformation(loggerMessage);
                        break;

                    case LogLevel.Warning:
                        _Logger.LogWarning(loggerMessage);
                        break;

                    case LogLevel.Error:
                        _Logger.LogError(loggerMessage);
                        break;

                    case LogLevel.Critical:
                        _Logger.LogCritical(loggerMessage);
                        break;
                }
            }
        }
    }
}
