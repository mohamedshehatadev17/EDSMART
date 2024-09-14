using EduSmart.Application.DTOS;
using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ILessonCompletion _lessonCompletion;

        public ProgressService(IProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        public async Task<IEnumerable<Progress>> GetProgressByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException("Invalid student ID.");
            }

            return await _progressRepository.GetProgressByStudentIdAsync(studentId);
        }

        public async Task<Progress> GetProgressByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid progress ID.");
            }

            return await _progressRepository.GetProgressByIdAsync(id);
        }

        public async Task AddProgressAsync(Progress progress)
        {
            // Example validation or business logic
            if (progress.StudentId <= 0 || progress.ModuleId <= 0)
            {
                throw new ArgumentException("Invalid student or module ID.");
            }

            await _progressRepository.AddProgressAsync(progress);
            await _progressRepository.SaveChangesAsync();
        }

        public async Task UpdateProgressAsync(Progress progress)
        {
            // Example validation or business logic
            if (progress.Id <= 0)
            {
                throw new ArgumentException("Invalid progress ID.");
            }

            await _progressRepository.UpdateProgressAsync(progress);
            await _progressRepository.SaveChangesAsync();
        }

        public async Task DeleteProgressAsync(int id)
        {
            // Example validation or business logic
            if (id <= 0)
            {
                throw new ArgumentException("Invalid progress ID.");
            }

            await _progressRepository.DeleteProgressAsync(id);
           await _progressRepository.SaveChangesAsync();
        }

        // Method to mark a lesson as complete for a student
        public async Task<bool> MarkLessonCompleteAsync(int lessonId, int studentId)
        {
            // Check if the lesson exists
            var lesson = await _lessonRepository.GetLessonByIdAsync(lessonId);
            if (lesson == null)
            {
                return false; // Lesson not found
            }

            // Check if the student exists
            var student = await _studentRepository.GetStudentByIdAsync(studentId); 
            if (student == null)
            {
                return false; // Student not found
            }

            // Check if the lesson has already been marked as complete for the student
             await _lessonRepository.MarkStudentLessonCompleted(lessonId, studentId);


            // Mark the lesson as complete by adding a new record
            var lessonCompletion = new LessonCompletion
            {
                LessonId = lessonId,
                studentId = studentId,
            };

             _lessonCompletion.AddLessonCompletion(lessonCompletion);
            return await _progressRepository.SaveChangesAsync();
        }

       







    }
}