using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Core.Entities
{
    public class QuizOption
    {   
            public int Id { get; set; }
            public string OptionText { get; set; }
            [ForeignKey("Quiz")]
            public int QuizId { get; set; }
            public Quiz Quiz { get; set; } // Navigation Property
        


    }
}
