using EduSmart.Application.Services;
using EduSmart.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;      
       public CategoryController(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromForm]string Name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryService.AddCategory(Name);
            return Created(); 
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategory()
        {
            var categories = await _categoryService.GetAllCategory();
            return (categories);
        }

    }
}
