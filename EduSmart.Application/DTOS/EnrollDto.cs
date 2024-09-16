using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.DTOS
{
    public class EnrollDto
    {

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }


    }
}
