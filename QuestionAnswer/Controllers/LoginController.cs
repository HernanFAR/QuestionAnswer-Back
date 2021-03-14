using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;
using Quicker.Controller.Constants;
using QuestionAnswer.Interface;
using Service.Exceptions;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase, ILoginController
    {
        private readonly ILoginService _LoginService;

        public LoginController(ILoginService loginService)
        {
            _LoginService = loginService;
        }

        [HttpPost("register")]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<UserCreated>> Register([FromBody] RegisterData model)
        {
            ActionResult<UserCreated> response;

            try
            {
                response = StatusCode(StatusCodes.Status201Created, await _LoginService.RegisterUser(model));
            }
            catch (ValidationException ex)
            {
                response = UnprocessableEntity(ex.Errors);
            }

            return response;
        }

        [HttpPost("authenticate")]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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
            catch (WrongPasswordException ex)
            {
                response = StatusCode(StatusCodes.Status406NotAcceptable, ex.TryCount);
            }
            catch (LockedUserException ex)
            {
                response = StatusCode(StatusCodes.Status409Conflict, ex.Time);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "user")
                    response = NotFound();
                else if (ex.Message == "IsNotAllowed")
                    response = StatusCode(StatusCodes.Status409Conflict);
                else throw;
            }

            return response;
        }

        [HttpPatch("update")]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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

        [HttpPatch("addPassword")]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> AddPassword([FromBody] PasswordData model)
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
