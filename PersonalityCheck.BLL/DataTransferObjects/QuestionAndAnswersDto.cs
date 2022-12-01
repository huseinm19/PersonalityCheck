using PersonalityCheck.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityCheck.BLL.DataTransferObjects
{
    public class QuestionAndAnswersDto
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }

        public QuestionAndAnswersDto(Question question, List<Answer> answers)
        {
            Question = question;
            Answers = answers;
        }
    }
}
