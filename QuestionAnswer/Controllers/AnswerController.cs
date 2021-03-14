using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.Interface;
using Quicker.Abstracts.Controller;
using Quicker.Controller.Constants;
using Repository.DTO;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    public class AnswerController : CloseControllerAsync<int, Answer, AnswerDTO, IAnswerService>, IAnswerController
    {
        public AnswerController(IAnswerService service) :
            base(service) { }


        [HttpPost]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<AnswerDTO>> Create([FromBody] AnswerDTO entity)
        {
            ActionResult<AnswerDTO> actionResult;

            try
            {
                actionResult = StatusCode(StatusCodes.Status201Created, await Service.Create(entity));
            }
            catch (ArgumentNullException)
            {
                actionResult = BadRequest();
            }
            catch (InvalidOperationException ex)
            {
                actionResult = Conflict(ex.Message);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                actionResult = Conflict(ex.Message);
            }
            catch (ValidationException ex)
            {
                actionResult = UnprocessableEntity(ex.Errors);
            }
            catch (DbUpdateException ex)
            {
                actionResult = UnprocessableEntity(ex.Message);
            }

            return actionResult;
        }

        [HttpDelete]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> Delete([FromBody] int key)
        {
            ActionResult actionResult;

            try
            {
                var identityId = HttpContext.User.FindFirst(ClaimTypes.GivenName).Value ?? string.Empty;

                await Service.Delete(key, identityId);

                actionResult = Ok();
            }
            catch (ArgumentNullException)
            {
                actionResult = BadRequest();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "entity")
                    actionResult = StatusCode(StatusCodes.Status406NotAcceptable);
                else
                    actionResult = Conflict(ex.Message);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                actionResult = Conflict(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                actionResult = UnprocessableEntity(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("topVoted/{count}")]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<AnswerDTO>>> GetTopVoted(int count)
        {
            ActionResult<IEnumerable<AnswerDTO>> result;

            try
            {
                var entities = await Service.GetTopVoted(count);

                if (entities.ToList().Count == 0)
                    result = NoContent();
                else
                    result = Ok(entities);
            }
            catch (ArgumentException ex)
            {
                result = UnprocessableEntity(ex.Message);
            }

            return result;
        }

        [HttpGet("getBottomVoted/{count}")]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<AnswerDTO>>> GetBottomVoted(int count)
        {
            ActionResult<IEnumerable<AnswerDTO>> result;

            try
            {
                var entities = await Service.GetBottomVoted(count);

                if (entities.ToList().Count == 0)
                    result = NoContent();
                else
                    result = Ok(entities);
            }
            catch (ArgumentException ex)
            {
                result = UnprocessableEntity(ex.Message);
            }

            return result;
        }
    }
}
