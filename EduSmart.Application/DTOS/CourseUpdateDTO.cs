using EduSmart.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.DTOS
{
    public class CourseUpdateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int InstructorId { get; set; }
    }

}
