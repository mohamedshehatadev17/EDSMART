using EduSmart.Application.Services;
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
        [HttpPost("/Create")]
        public async Task<ActionResult> CreateCategory([FromForm]string Name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryService.AddCategory(Name);
            return Created(); 
        }
    }
}
