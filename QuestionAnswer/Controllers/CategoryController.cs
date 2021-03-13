using Microsoft.AspNetCore.Mvc;
using Quicker.Abstracts.Controller;
using Repository.Models;
using Service.Interfaces;

namespace QuestionAnswer.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : CloseControllerAsync<int, Category, ICategoryService>, ICategoryController
    {
        public CategoryController(ICategoryService service) : 
            base(service) { }
    }
}
