using AutoMapper;
using EduSmart.Application.Services;
using EduSmart.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors.Infrastructure;
using EduSmart.Application.DTOS;
using EduSmart.Core.Entities;

namespace EduSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/course
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        // GET: api/course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromForm] CourseDTO courseDto, IFormFile CourseImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             await _courseService.AddCourseAsync(courseDto, CourseImage);
            return Ok(new { message = "created successfully" });
        }

        // PUT: api/course/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromForm] CourseUpdateDTO courseDto, [FromForm] IFormFile image)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

                await _courseService.UpdateCourseAsync(id, courseDto, image);
            return NoContent(); //NoContent();
        }

        // DELETE: api/course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }

        // POST: api/course/student/enroll/5
        [HttpPost("student/enroll/{courseId:int}/{StudentId:int}")]
        public async Task<IActionResult> EnrollStudent(int courseId,int StudentId)
        {
            var result = await _courseService.EnrollStudentAsync(courseId, StudentId);
            if (!result) return BadRequest("Enrollment failed.");
            return Ok("Enrollment successful.");
        }
    }

}
