using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.DTO
{
    public class QuestionDTO: BaseEntityDTO
    {
        public string Text { get; set; }
        public string DataType { get; set; }
        public string[] Enumeration { get; set; }
    }
}
