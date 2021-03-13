using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Interface;
using Quicker.Abstracts.Controller;
using Quicker.Controller.Constants;
using Repository.DTO;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    public class AnswerController : OpenControllerAsync<int, Answer, AnswerDTO, IAnswerService>, IAnswerController
    {
        public AnswerController(IAnswerService service) :
            base(service) { }
        
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
