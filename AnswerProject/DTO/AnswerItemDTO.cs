using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.DTO
{
    public class AnswerItemDTO: BaseEntityDTO
    {
        public long Question_Id { get; set; }
        public string QuestionText { get; set; }
        public string Value { get; set; }
    }
}
