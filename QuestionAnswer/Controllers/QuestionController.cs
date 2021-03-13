using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Interface;
using Quicker.Abstracts.Controller;
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
    public class QuestionController : FullControllerAsync<int, Question, QuestionDTO, IQuestionService>, IQuestionController
    {
        public QuestionController(IQuestionService service) : 
            base(service) { }

        [HttpGet("bottomVoted/{count}")]
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
