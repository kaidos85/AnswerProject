using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Models
{
    public class Question: BaseEntity
    {
        public string Text { get; set; }
        public string DataType { get; set; }
        public string Enumeration { get; set; }
    }
}
