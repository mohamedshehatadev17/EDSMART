using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{ 
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
       Task<Student> GetStudentByIdAsync(int id);
        Task EnrollStudentInCourseAsync(StudentCourse studentCourse);
        Task UpdateStudentProgressAsync(Progress progress);
        Task<bool> SaveChangesAsync();
    }

}
