using EduSmart.Application.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduSmart.Application.Interfaces;
using EduSmart.Application.Services;
using EduSmart.Core.Entities;

namespace EduSmart.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("{moduleId}")]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetLessonsByModuleId(int moduleId)
        {
            var lessons = await _lessonService.GetLessonsByModuleIdAsync(moduleId);
            return Ok();
        }

        [HttpGet("lesson/{id}")]
        public async Task<ActionResult<LessonDTO>> GetLessonById(int id)
        {
            var lessonDTO = await _lessonService.GetLessonByIdAsync(id);
            if (lessonDTO == null)
            {
                return NotFound();
            }
            return Ok(lessonDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonDTO lessonDTO)
        {

            await _lessonService.AddLessonAsync(lessonDTO);
            return CreatedAtAction(nameof(GetLessonById), new { id = lessonDTO.Id }, lessonDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonDTO lessonDTO)
        {
            if (id != lessonDTO.Id)
            {
                return BadRequest();
            }

            await _lessonService.UpdateLessonAsync(lessonDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonService.DeleteLessonAsync(id);
            return NoContent();
        }

    }
}