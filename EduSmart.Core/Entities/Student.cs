using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<StudentCourse> Enrollments { get; set; } // A student can enroll in multiple courses
        public ICollection<Progress> Progresses { get; set; } // A student has progress in multiple courses
        public ICollection<LessonCompletion> LessonCompletions { get; set; }

    }

}
