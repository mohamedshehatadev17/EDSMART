﻿using EduSmart.Core.Entities;
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
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public IFormFile? CourseImage { get; set; }
        public Category? Category { get; set; }
    }

}
