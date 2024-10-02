using EduSmart.Application.DTOS;
using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using EduSmart.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace EduSmart.Application.Services
{

    public class LessonService :ILessonService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository, IWebHostEnvironment webHostEnvironment)
        {
            _lessonRepository = lessonRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsByModuleIdAsync(int moduleId)
        {
            var lessons = await _lessonRepository.GetLessonsByModuleIdAsync(moduleId);
            if (lessons == null || !lessons.Any())
            {
                throw new KeyNotFoundException($"No lessons found for module with Id {moduleId}");
            }
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

        public async Task AddLessonAsync(LessonCreateDto LessonCreateDto)
        {
            if (LessonCreateDto == null)
            {
                throw new ArgumentNullException(nameof(LessonCreateDto));
            }

            var lesson = new Lesson
            {
                Title = LessonCreateDto.Title ?? throw new ArgumentException("Title cannot be null"),
                ModuleId = LessonCreateDto.ModuleId
            };

            if (LessonCreateDto.VideoFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + LessonCreateDto.VideoFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                Directory.CreateDirectory(uploadsFolder); // Ensure the uploads folder exists

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await LessonCreateDto.VideoFile.CopyToAsync(fileStream);
                }

                lesson.Content += $"\n[VIDEO]/uploads/{uniqueFileName}[/VIDEO]";
            }

            await _lessonRepository.AddLessonAsync(lesson);
        }

        public async Task UpdateLessonAsync(int id, LessonDTO lessonDTO)
        {
            var lesson = await _lessonRepository.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                throw new KeyNotFoundException($"Lesson with id {id} not found");
            }

            lesson.Title = lessonDTO.Title;
            lesson.Content = lessonDTO.Content;
            lesson.ModuleId = lessonDTO.ModuleId;

            if (lessonDTO.VideoFile != null)
            {
                // Remove old video path from content if exists
                lesson.Content = RemoveOldVideoPath(lesson.Content);

                // Delete old video file if exists
                DeleteOldVideoFile(lesson.Content);

                // Upload new video
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + lessonDTO.VideoFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await lessonDTO.VideoFile.CopyToAsync(fileStream);
                }

                string videoPath = "/uploads/" + uniqueFileName;

                // Append the new video path to the content
                lesson.Content += $"\n[VIDEO]{videoPath}[/VIDEO]";
            }

            await _lessonRepository.UpdateLessonAsync(lesson);
        }

        private string RemoveOldVideoPath(string content)
        {
            // Remove the old video path from the content
            return System.Text.RegularExpressions.Regex.Replace(content, @"\[VIDEO\].*?\[/VIDEO\]", "");
        }

        private void DeleteOldVideoFile(string content)
        {
            var match = System.Text.RegularExpressions.Regex.Match(content, @"\[VIDEO\](.*?)\[/VIDEO\]");
            if (match.Success)
            {
                string oldVideoPath = match.Groups[1].Value;
                var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, oldVideoPath.TrimStart('/'));
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }
        }


        public async Task DeleteLessonAsync(int lessonId)
        {
            await _lessonRepository.DeleteLessonAsync(lessonId);
        }

       

       
    }
}
