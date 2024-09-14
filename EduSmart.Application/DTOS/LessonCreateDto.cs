using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.DTOS
{
    public class LessonCreateDto
    {
        public int Id {  get; set; }
        public string? Title { get; set; }
        public int ModuleId { get; set; }
        public string? Content { get; set; } // Text, Video URL, or PDF URL
    }

}
