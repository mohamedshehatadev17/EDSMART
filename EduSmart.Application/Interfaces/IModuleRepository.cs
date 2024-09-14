using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetModulesByCourseIdAsync(int courseId);
        Task<Module> GetModuleByIdAsync(int id);
        Task AddModuleAsync(Module module);
        Task UpdateModuleAsync(Module module);
        Task<bool> SaveChangesAsync();

        Task DeleteModuleAsync(int id);
    }

}
