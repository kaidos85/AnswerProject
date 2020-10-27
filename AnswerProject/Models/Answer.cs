using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Models
{
    public class Answer: BaseEntity
    {
        public DateTime ADate { get; set; }
        public string UserName { get; set; }
        public virtual List<AnswerItem> AnswerItems { get; set; }
    }
}
