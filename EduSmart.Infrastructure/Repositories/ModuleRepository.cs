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
    public class ModuleRepository : IModuleRepository
    {
        private readonly EDContext _context;

        public ModuleRepository(EDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Module>> GetModulesByCourseIdAsync(int courseId)
        {
            return await _context.Modules
                .Where(m => m.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Module> GetModuleByIdAsync(int id)
        {
            return await _context.Modules
                .Include(m => m.Lessons)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddModuleAsync(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateModuleAsync(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModuleAsync(int id)
        {
            var module = await GetModuleByIdAsync(id);
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}