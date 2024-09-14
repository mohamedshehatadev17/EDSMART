using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        // Method to enroll a student in a course
        Task<bool> EnrollStudentAsync(int courseId, int studentId);

        // Method to get enrollment details for a specific course and student
        Task<Enrollment> GetEnrollmentAsync(int courseId, int studentId);

        // Method to get all enrollments for a specific course
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(int courseId);

        // Method to get all courses a student is enrolled in
        Task<IEnumerable<Enrollment>> GetCoursesByStudentAsync(string studentId);

        // Method to remove an enrollment (unenroll a student from a course)
        Task<bool> UnenrollStudentAsync(int courseId, string studentId);

        void AddEnrollment(Enrollment enrollment);

        // Optional: Save changes to the database
        Task<bool> SaveChangesAsync();
    }

}
