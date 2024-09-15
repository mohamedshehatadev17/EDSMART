using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.DTOS
{
    public class QuizSubmissionDto
    {
        public int StudentId { get; set; }
        public Dictionary<int, string>? Answers { get; set; } // QuestionId, Answer
    }

}
