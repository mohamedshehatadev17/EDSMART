using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class CompletionCertificate
    {
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; } // Navigation Property
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; } // Navigation Property
        public DateTime DateIssued { get; set; }
        public string? CertificateUrl { get; set; } // URL to the generated certificate (e.g., PDF)
    }

}
