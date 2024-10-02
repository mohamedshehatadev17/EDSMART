using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EduSmart.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EDContext _context;

        public CourseRepository(EDContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.Include(c=>c.Modules).ToListAsync();
                //.Include(c => c.Category)
                //.Include(c => c.Instructor)
                //.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses
                .Include( c => c.Modules)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await GetCourseByIdAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
