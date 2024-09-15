using EduSmart.Application.DTOS;
using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IEnumerable<Module>> GetModulesByCourseIdAsync(int courseId)
        {
            return await _moduleRepository.GetModulesByCourseIdAsync(courseId);
        }

        public async Task<Module> GetModuleByIdAsync(int id)
        {
            return await _moduleRepository.GetModuleByIdAsync(id);
        }

        public async Task AddModuleAsync(ModuleCreateDto moduleCreateDto)
        {
            // Example validation or business logic
            if (string.IsNullOrWhiteSpace(moduleCreateDto.Title))
            {
                throw new ArgumentException("Module title is required.");
            }
            Module module = new()
            {
                Title= moduleCreateDto.Title,
                CourseId=moduleCreateDto.CourseId, 
                Description=moduleCreateDto.Description
            };
            await _moduleRepository.AddModuleAsync(module);
        }

        public async Task UpdateModuleAsync(Module module)
        {
            // Example validation or business logic
            if (module.Id <= 0)
            {
                throw new ArgumentException("Invalid module ID.");
            }
            await _moduleRepository.UpdateModuleAsync(module);
        }

        public async Task DeleteModuleAsync(int id)
        {
            // Example validation or business logic
            if (id <= 0)
            {
                throw new ArgumentException("Invalid module ID.");
            }
            await _moduleRepository.DeleteModuleAsync(id);
        }
    }
}