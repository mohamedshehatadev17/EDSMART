using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.DTOS
{
    public class LessonDTO
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public int ModuleId { get; set; }
        public IFormFile VideoFile { get; set; }
    }
}

