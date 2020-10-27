using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Models
{
    public class AnswerItem: BaseEntity
    {
        public long Question_Id { get; set; }
        [ForeignKey("Question_Id")]
        public virtual Question Question { get; set; }
        public long Answer_Id { get; set; }
        [ForeignKey("Answer_Id")]
        public virtual Answer Answer { get; set; }
        public string Value { get; set; }
    }
}
