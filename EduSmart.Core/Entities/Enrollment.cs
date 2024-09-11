using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
      class Enrollment
    {
        public int Id { get; set; }

       // [Required]
       // public string StudentId { get; set; }

        //[ForeignKey("StudentId")]
       // public virtual ApplicationUser Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public DateTime EnrolledAt { get; set; }
    }
}
