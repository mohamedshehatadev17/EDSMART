using EduSmart.Application.DTOS;
using EduSmart.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        // GET: api/module/course/5
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetModulesByCourseId(int courseId)
        {
            var modules = await _moduleService.GetModulesByCourseIdAsync(courseId);
            return Ok(modules);
        }

        // POST: api/module
        [HttpPost]
        public async Task<IActionResult> CreateModule([FromBody] ModuleCreateDto moduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Assuming AddModuleAsync returns the created Module object.
            var createdModule = await _moduleService.AddModuleAsync(moduleDto);

            // Assuming GetModulesByCourseId expects courseId as a route parameter.
            return CreatedAtAction(
                nameof(GetModulesByCourseId),
                new { courseId = moduleDto.CourseId },
                createdModule // Return the created module as part of the response
            );
        }
    }

}
