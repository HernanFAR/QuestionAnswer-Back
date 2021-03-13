using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _LoginService;

        public LoginController(ILoginService loginService)
        {
            _LoginService = loginService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserCreated>> Register([FromBody] RegisterData model)
        {
            ActionResult<UserCreated> response;

            try
            {
                response = Ok(await _LoginService.RegisterUser(model));
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }

            return response;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<TokenData>> Login([FromBody] LoginSession model)
        {
            ActionResult response;

            try
            {
                response = Ok(await _LoginService.LoginUser(model));
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else throw;
            }

            return response;
        }

        [HttpPatch("update")]
        public async Task<ActionResult<TokenData>> UpdateInformation([FromBody] ChangeInformation model)
        {
            ActionResult response;

            try
            {
                await _LoginService.UpdateInformation(model);

                response = Ok();
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else throw;
            }

            return response;
        }

        [HttpPatch("confirmEmail/{userId}")]
        public async Task<ActionResult> ConfirmEmail([FromRoute] string userId, [FromQuery] string token)
        {
            ActionResult response;

            try
            {
                var model = new ConfirmEmailData
                {
                    UserId = userId,
                    Token = token
                };

                await _LoginService.ConfirmEmail(model);

                response = Ok();
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else throw;
            }

            return response;

        }

        [HttpGet("forgetPassword")]
        public async Task<ActionResult> ForgetPassword([FromQuery] string email)
        {
            ActionResult response;

            try
            {
                await _LoginService.ForgetPassword(email);

                response = Ok();
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else if (ex.Message == "StatusCode")
                    response = Conflict();
                else throw;
            }

            return response;
        }

        [HttpPatch("resetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPassword model)
        {
            ActionResult response;

            try
            {
                await _LoginService.ResetPassword(model);

                response = Ok();
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else throw;
            }

            return response;
        }

        [HttpGet("sendConfirmation")]
        public async Task<ActionResult> SendConfirm([FromQuery] string email)
        {
            ActionResult response;

            try
            {
                await _LoginService.SendConfirmEmail(email);
                
                response = Ok();
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else if (ex.Message == "StatusCode")
                    response = Conflict();
                else throw;
            }

            return response;
        }

        [HttpPatch("sendConfirmation")]
        public async Task<ActionResult> SendConfirm([FromBody] PasswordData model)
        {
            ActionResult response;

            try
            {
                await _LoginService.AddPassword(model);
                
                response = Ok();
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else if (ex.Message == "StatusCode")
                    response = Conflict();
                else throw;
            }

            return response;
        }
    }
}
