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
    public class LessonCompletionRepository : ILessonCompletion
    {
        private readonly EDContext _context;
        public LessonCompletionRepository(EDContext context)
        {
            _context = context;
        }

        public void AddLessonCompletion(LessonCompletion lessonCompletion)
        {
            _context.LessonsCompletions.AddAsync(lessonCompletion);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
