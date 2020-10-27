﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
