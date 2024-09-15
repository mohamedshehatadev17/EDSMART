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
    public class StudentRepository : IStudentRepository
    {
        private readonly EDContext _context;

        public StudentRepository(EDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task EnrollStudentInCourseAsync(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentProgressAsync(Progress progress)
        {
            _context.Progresses.Update(progress);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

