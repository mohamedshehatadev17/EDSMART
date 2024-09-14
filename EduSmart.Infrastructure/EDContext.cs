using Microsoft.EntityFrameworkCore;
using EduSmart.Core.Entities;

namespace EduSmart.Infrastructure
{
    public class EDContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<LessonCompletion> LessonsCompletions { get; set; }
        public DbSet<CompletionCertificate> CompletionCertificates { get; set; }
        public EDContext(DbContextOptions<EDContext> options): base(options)
        {
        }




    }
}
