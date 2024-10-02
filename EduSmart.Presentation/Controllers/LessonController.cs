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
            return Ok(lessons);
        }

        [HttpGet("{id:int}")]
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
        public async Task<IActionResult> AddLesson([FromForm] LessonCreateDto LessonCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _lessonService.AddLessonAsync(LessonCreateDto);
                return Created();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, [FromForm] LessonDTO lessonDTO)
        {
            if (lessonDTO.VideoFile != null)
            {
                if (!IsValidVideoFile(lessonDTO.VideoFile))
                {
                    return BadRequest("Invalid video file. Only .mp4 files are allowed.");
                }
            }

            await _lessonService.UpdateLessonAsync(id, lessonDTO);
            return NoContent();
        }

        private bool IsValidVideoFile(IFormFile file)
        {
            // Check if the file is a video file (you might want to add more checks)
            return file.ContentType.ToLower() == "video/mp4";
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonService.DeleteLessonAsync(id);
            return NoContent();
        }

    }
}