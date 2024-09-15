using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetLessonsByModuleIdAsync(int moduleId);
        Task<Lesson> GetLessonByIdAsync(int lessonId);
        Task AddLessonAsync(Lesson lesson);
        Task UpdateLessonAsync(Lesson lesson);
        Task DeleteLessonAsync(int lessonId);
        Task MarkStudentLessonCompleted(int lessonId, int studentId);
        Task<bool> SaveChangesAsync();

    }
}
