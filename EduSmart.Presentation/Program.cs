using EduSmart.Application.Interfaces;
using EduSmart.Application.Services;
using EduSmart.Infrastructure;
using EduSmart.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EduSmart.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add DbContext
            builder.Services.AddDbContext<EDContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EduSmart")));

            // Add Repositories
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
            builder.Services.AddScoped<ILessonRepository, LessonRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<ILessonCompletion, LessonCompletionRepository>();

            // Add Services
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IModuleService, ModuleService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IProgressService, ProgressService>();
            builder.Services.AddScoped<ILessonService, LessonService>();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Swagger Configuration
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EduSmart API",
                    Version = "v1",
                    Description = "API documentation for the EduSmart application"
                });
            });

            // Configure JSON options
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EduSmart API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
