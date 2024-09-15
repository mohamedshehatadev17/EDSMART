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
    public class LessonRepository : ILessonRepository
    {
        private readonly EDContext _context;

        public LessonRepository(EDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByModuleIdAsync(int moduleId)
        {
            return await _context.Lessons
                .Where(l => l.ModuleId == moduleId)
                .ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(int lessonId)
        {
            return await _context.Lessons
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }

        public async Task AddLessonAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLessonAsync(int lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();
            }
        }

        public Task MarkStudentLessonCompleted(int lessonId, int studentId)
        {
            return _context.LessonsCompletions
                .FirstOrDefaultAsync(lc => lc.LessonId == lessonId && lc.Student.Id == studentId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
