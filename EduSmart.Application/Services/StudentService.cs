using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EduSmart.Core.Entities;
    using EduSmart.Application.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task EnrollStudentInCourseAsync(StudentCourse studentCourse)
        {
            // Example validation or business logic
            if (studentCourse.StudentId <= 0 || studentCourse.CourseId <= 0)
            {
                throw new ArgumentException("Invalid student or course ID.");
            }
            await _studentRepository.EnrollStudentInCourseAsync(studentCourse);
        }

        #region MyRegion

        public async Task<bool> EnrollStudentAsync(int courseId, int studentId)
        {
            // Find the course by courseId
            var course = _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null)
                return false; // Course not found

            // Find the student by studentId
            var student = _studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
                return false; // Student not found

            // Check if the student is already enrolled in the course
            var enrollment = await _enrollmentRepository.EnrollStudentAsync(courseId, studentId);

            if (enrollment != null)
                return false; // Student is already enrolled

            // Enroll the student
            var newEnrollment = new Enrollment
            {
                CourseId = courseId,
                StudentId = studentId,
            };

             _enrollmentRepository.AddEnrollment(newEnrollment);
              await _studentRepository.SaveChangesAsync();

            return true;
        }
        #endregion









        public async Task UpdateStudentProgressAsync(Progress progress)
        {
            // Example validation or business logic
            if (progress.StudentId <= 0 || progress.ModuleId <= 0)
            {
                throw new ArgumentException("Invalid progress data.");
            }
            await _studentRepository.UpdateStudentProgressAsync(progress);
        }
    }

}
