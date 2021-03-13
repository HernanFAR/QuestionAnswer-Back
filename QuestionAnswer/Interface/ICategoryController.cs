using Quicker.Interfaces.WebApiController;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswer.Controllers
{
    public interface ICategoryController : ICloseControllerAsync<int, Category>
    {
    }
}
