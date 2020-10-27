using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.DTO
{
    public class AnswerDTO: BaseEntityDTO
    {
        public DateTime ADate { get; set; }
        public string UserName { get; set; }
        public virtual List<AnswerItemDTO> AnswerItems { get; set; }
    }
}
