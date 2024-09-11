using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class Category
    {
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            public string Description { get; set; }

            public virtual ICollection<Course> Courses { get; set; }
        }
}
