using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EduSmart.Core.Entities
{

    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? CourseImage { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        [Required]
        public Instructor? Instructor { get; set; }

        [Required]
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
        [Required]
        public virtual ICollection<Module>? Modules { get; set; }

    }
}
