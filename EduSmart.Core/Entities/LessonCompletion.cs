using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class LessonCompletion
    {
        public int Id { get; set; } 
        // Composite primary key or unique constraint can be applied on LessonId and StudentId
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        [ForeignKey("Student")]
        public int studentId { get; set; }

        // Navigation properties to relate to other entities
        public Lesson Lesson { get; set; } // Each completion corresponds to a specific lesson
        public Student Student { get; set; } // Each completion corresponds to a specific student
    }

}
