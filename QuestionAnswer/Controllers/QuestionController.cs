using FluentValidation;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class QuestionController : CloseControllerAsync<int, Question, QuestionDTO, IQuestionService>, IQuestionController
    {
        public QuestionController(IQuestionService service) : 
            base(service) { }

        [HttpDelete("{key}")]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> Delete(int key)
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

        [HttpPost]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<QuestionDTO>> Create([FromBody] QuestionDTO entity)
        {
            ActionResult<QuestionDTO> actionResult;

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


        [HttpPut("{key}")]
        [Consumes(ControllerConstants.JsonContentType)]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<QuestionDTO>> Update([FromQuery] int key, [FromBody] QuestionDTO entity)
        {
            ActionResult<QuestionDTO> actionResult;

            try
            {
                var updated = await Service.Update(key, entity);

                if (updated != null)
                    actionResult = Ok(updated);
                else
                    actionResult = NotFound();
            }
            catch (ArgumentNullException)
            {
                actionResult = BadRequest();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "key")
                    actionResult = StatusCode(StatusCodes.Status406NotAcceptable);
                else
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

        [HttpGet("bottomVoted/{count}")]
        [AllowAnonymous]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetBottomVoted(int count)
        {
            ActionResult<IEnumerable<QuestionDTO>> result;

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

        [HttpGet("ofUser/{identityId}")]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetOfUser(string identityId)
        {
            ActionResult<IEnumerable<QuestionDTO>> result;

            try
            {
                var entities = await Service.GetOfUser(identityId);

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

        [HttpGet("withCategory/{categoryId}")]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestionsWithCategory(int categoryId)
        {
            ActionResult<IEnumerable<QuestionDTO>> result;

            try
            {
                var entities = await Service.GetQuestionsWithCategory(categoryId);

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

        [HttpGet("topVoted/{count}")]
        [AllowAnonymous]
        [Produces(ControllerConstants.JsonContentType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetTopVoted(int count)
        {
            ActionResult<IEnumerable<QuestionDTO>> result;

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
    }
}
