using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduSmart.Application.Services;
using EduSmart.Application.DTOS;

namespace EduSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        //// GET: api/progress/course/5/student/10
        //[HttpGet("course/{courseId}/student/{studentId}")]
        //public async Task<IActionResult> GetCourseProgress(int courseId, int studentId)
        //{
        //    var progress = await _progressService.GetCourseProgressAsync(courseId, studentId);
        //    if (progress == null) return NotFound();
        //    return Ok(progress);
        //}

        // POST: api/progress/complete/lesson/5
        [HttpPost("complete/lesson/{lessonId}")]
        public async Task<IActionResult> MarkLessonComplete(int lessonId, [FromBody] ProgressUpdateDto progressDto)
        {
            var result = await _progressService.MarkLessonCompleteAsync(lessonId, progressDto.StudentId);
            if (!result) return BadRequest("Progress update failed.");
            return Ok("Lesson completed.");
        }

        //// GET: api/progress/completion-certificate/course/5/student/10
        //[HttpGet("completion-certificate/course/{courseId}/student/{studentId}")]
        //public async Task<IActionResult> GenerateCertificate(int courseId, int studentId)
        //{
        //    var certificate = await _progressService.GenerateCompletionCertificateAsync(courseId, studentId);
        //    if (certificate == null) return NotFound();
        //    return File(certificate, "application/pdf", "CompletionCertificate.pdf");
        //}
    }

}
