using EduSmart.Application.DTOS;
using EduSmart.Application.FileSetting;
using EduSmart.Application.Interfaces;
using EduSmart.Application.Services;
using EduSmart.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly string _imagesPath;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CourseService(
        IWebHostEnvironment webHostEnvironment,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository,
        IEnrollmentRepository enrollmentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _enrollmentRepository = enrollmentRepository;
        _webHostEnvironment = webHostEnvironment;
        _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAllCoursesAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _courseRepository.GetCourseByIdAsync(id);
    }

    public async Task AddCourseAsync(CourseDTO courseDto, IFormFile img)
    {
        if (string.IsNullOrWhiteSpace(courseDto.Title))
        {
            throw new ArgumentException("Course title is required.");
        }

        if (img == null || img.Length == 0)
        {
            throw new ArgumentException("An image is required.");
        }


        
        string imageBase64 = await ConvertImageToBase64(img);

        Course course = new()
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Price = courseDto.Price,
            CategoryId = courseDto.CategoryId, // Ensure this exists in the Categories table
            InstructorId = courseDto.InstructorId
        };
        course.CourseImage = imageBase64;

        await _courseRepository.AddCourseAsync(course);
        await _courseRepository.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(string id, CourseUpdateDTO courseDTO, IFormFile img)
    {
        if (courseDTO.Id <= 0)
        {
            throw new ArgumentException("Invalid course ID.");
        }

        var existingCourse = await _courseRepository.GetCourseByIdAsync(courseDTO.Id);
        if (existingCourse == null)
        {
            throw new Exception("Course not found.");
        }

        existingCourse.Title = courseDTO.Title;
        existingCourse.Description = courseDTO.Description;
        existingCourse.Price = courseDTO.Price;

        if (img != null && img.Length > 0)
        {
            existingCourse.CourseImage = await ConvertImageToBase64(img);
        }

        await _courseRepository.UpdateCourseAsync(existingCourse);
        await _courseRepository.SaveChangesAsync();
    }

    public async Task<string> ConvertImageToBase64(IFormFile cover)
    {
        var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

        var path = Path.Combine(_imagesPath, coverName);

        using var stream = File.Create(path);
        await cover.CopyToAsync(stream);

        return coverName;
    }

    public async Task DeleteCourseAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid course ID.");
        }

        await _courseRepository.DeleteCourseAsync(id);
    }

    #region EnrollStudent
    public async Task<bool> EnrollStudentAsync(int courseId, int studentId)
    {
        return await _enrollmentRepository.EnrollStudentAsync(courseId, studentId);
    }

    public Task<bool> EnrollStudentAsync(int courseId, string studentId)
    {
        throw new NotImplementedException();
    }
    #endregion
}
