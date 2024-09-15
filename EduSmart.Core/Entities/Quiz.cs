using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public ICollection<QuizOption> Options { get; set; } // Multiple options for a question
        public int? ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }


    }
}
