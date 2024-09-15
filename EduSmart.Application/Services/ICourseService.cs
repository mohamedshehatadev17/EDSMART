using EduSmart.Application.DTOS;
using EduSmart.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
   
        public interface ICourseService
        {
            Task<IEnumerable<Course>> GetAllCoursesAsync();
            Task<Course> GetCourseByIdAsync(int id);
            Task AddCourseAsync(CourseDTO courseDto, IFormFile img);
            Task UpdateCourseAsync(string id, CourseUpdateDTO courseDTO, IFormFile? img);
            Task DeleteCourseAsync(int id);
            Task<bool> EnrollStudentAsync(int courseId, string studentId);
            Task<string> ConvertImageToBase64(IFormFile image);
    }
    
}
