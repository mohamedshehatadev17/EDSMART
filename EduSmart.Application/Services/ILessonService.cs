using EduSmart.Application.DTOS;
using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public  interface ILessonService
    {
        Task<IEnumerable<LessonDTO>> GetLessonsByModuleIdAsync(int moduleId);
        Task<LessonDTO> GetLessonByIdAsync(int lessonId);
        Task AddLessonAsync(LessonDTO lessonDTO);
        Task UpdateLessonAsync(int Id,LessonDTO lessonDTO);
        Task DeleteLessonAsync(int lessonId);
        //Task MarkStudentLessonCompleted(int lessonId,int studentId);
    }
}
