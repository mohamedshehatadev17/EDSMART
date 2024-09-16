using EduSmart.Application.DTOS;
using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public interface IModuleService
    {
        Task<IEnumerable<Module>> GetModulesByCourseIdAsync(int courseId);
        Task<Module> GetModuleByIdAsync(int id);
        Task<Module> AddModuleAsync(ModuleCreateDto moduleCreateDto);
        Task UpdateModuleAsync(Module module);
        Task DeleteModuleAsync(int id);
    }
}
