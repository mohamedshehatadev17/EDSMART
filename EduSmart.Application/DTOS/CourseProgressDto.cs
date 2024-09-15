using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.DTOS
{
    public class CourseProgressDto
    {
        public int CourseId { get; set; }
        public string StudentId { get; set; }
        public int CompletedLessons { get; set; }
        public int TotalLessons { get; set; }
        public double ProgressPercentage { get; set; }
    }
}
