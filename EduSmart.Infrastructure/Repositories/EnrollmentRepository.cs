using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly EDContext _context;

        // Constructor to inject the ApplicationDbContext
        public EnrollmentRepository(EDContext context)
        {
            _context = context;
        }

        // Method to enroll a student in a course
        public async Task<bool> EnrollStudentAsync(int courseId, int studentId)
        {
            // Check if the course exists
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
                return false; // Course not found

            // Check if the student exists
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return false; // Student not found

            // Check if the student is already enrolled in the course
            var existingEnrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.CourseId == courseId && e.Student.Id == studentId);

            if (existingEnrollment != null)
                return false; // Student is already enrolled

            // Create a new enrollment
            var enrollment = new Enrollment
            {
                CourseId = courseId,
                StudentId = studentId,
            };

            await _context.Enrollments.AddAsync(enrollment);
            return await SaveChangesAsync();
        }

        // Method to get enrollment details for a specific course and student
        public async Task<Enrollment> GetEnrollmentAsync(int courseId, int studentId)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);
        }

        // Method to get all enrollments for a specific course
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(int courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }

        // Method to get all courses a student is enrolled in
        public async Task<IEnumerable<Enrollment>> GetCoursesByStudentAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        // Method to remove an enrollment (unenroll a student from a course)
        public async Task<bool> UnenrollStudentAsync(int courseId, int studentId)
        {
            var enrollment = await GetEnrollmentAsync(courseId, studentId);
            if (enrollment == null)
                return false; // Enrollment not found

            _context.Enrollments.Remove(enrollment);
            return await SaveChangesAsync();
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.AddAsync(enrollment);
        }



        // Save changes to the database
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<IEnumerable<Enrollment>> GetCoursesByStudentAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnenrollStudentAsync(int courseId, string studentId)
        {
            throw new NotImplementedException();
        }
    }

}
