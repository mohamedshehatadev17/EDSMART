using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class Progress
    {

        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; } // Navigation Property
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; } // Navigation Property

        public int CompletedModules { get; set; } // Tracks the number of completed modules
        public bool IsCourseCompleted { get; set; } // Tracks whether the course is completed
    }

}
