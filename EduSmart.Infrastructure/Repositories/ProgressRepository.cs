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
    public class ProgressRepository : IProgressRepository
    {
        private readonly EDContext _context;
       
        public ProgressRepository(EDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Progress>> GetProgressByStudentIdAsync(int studentId)
        {
            return await _context.Progresses
                .Where(p => p.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<Progress> GetProgressByIdAsync(int id)
        {
            return await _context.Progresses
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProgressAsync(Progress progress)
        {
            await _context.Progresses.AddAsync(progress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgressAsync(Progress progress)
        {
            _context.Progresses.Update(progress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProgressAsync(int id)
        {
            var progress = await _context.Progresses.FindAsync(id);
            if (progress != null)
            {
                _context.Progresses.Remove(progress);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}