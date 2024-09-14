using EduSmart.Application.DTOS;
using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using EduSmart.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public class LessonService :ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsByModuleIdAsync(int moduleId)
        {
            var lessons = await _lessonRepository.GetLessonsByModuleIdAsync(moduleId);
            return lessons.Select(lesson => new LessonDTO
            {
                Title = lesson.Title,
                Content = lesson.Content,
                ModuleId = lesson.ModuleId
            });
        }

        public async Task<LessonDTO> GetLessonByIdAsync(int lessonId)
        {
            var lesson = await _lessonRepository.GetLessonByIdAsync(lessonId);
            return new LessonDTO
            {
                Title = lesson.Title,
                Content = lesson.Content,
                ModuleId = lesson.ModuleId
            };
        }

        public async Task AddLessonAsync(LessonDTO lessonDTO)
        {
            if (lessonDTO != null)
            {
                var lesson = new Lesson
                {
                    Title = lessonDTO.Title,
                    Content = lessonDTO.Content,
                    ModuleId = lessonDTO.ModuleId
                };
                await _lessonRepository.AddLessonAsync(lesson);
            }
            else
            {
                throw new Exception("not valid");
            }

        }

        public async Task UpdateLessonAsync(LessonDTO lessonDTO)
        {
            var lesson = await _lessonRepository.GetLessonByIdAsync(lessonDTO.Id);
            if (lesson != null)
            {
                lesson.Title = lessonDTO.Title;
                lesson.Content = lessonDTO.Content;
                lesson.ModuleId = lessonDTO.ModuleId;
                await _lessonRepository.UpdateLessonAsync(lesson);
            }
        }

        public async Task DeleteLessonAsync(int lessonId)
        {
            await _lessonRepository.DeleteLessonAsync(lessonId);
        }

        Task<IEnumerable<Lesson>> ILessonService.GetLessonsByModuleIdAsync(int moduleId)
        {
            throw new NotImplementedException();
        }

       
    }
}
