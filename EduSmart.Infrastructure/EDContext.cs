using Microsoft.EntityFrameworkCore;
using EduSmart.Core.Entities;

namespace EduSmart.Infrastructure
{
    public class EDContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<MultimediaContent> MultimediaContents { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<QuizOption> QuizOptions { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public EDContext(DbContextOptions<EDContext> options): base(options)
        {
        }




    }
}
