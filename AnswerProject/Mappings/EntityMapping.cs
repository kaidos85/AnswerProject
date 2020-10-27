using AnswerProject.DTO;
using AnswerProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Mappings
{
    public class EntityMapping: Profile
    {
        public EntityMapping()
        {
            CreateMap<Question, QuestionDTO>()
                .ForMember(c => c.Enumeration, opt => opt.MapFrom(v => v.Enumeration.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();
            CreateMap<AnswerItem, AnswerItemDTO>()
                .ForMember(c => c.QuestionText, opt=> opt.MapFrom(v => v.Question.Text));
            CreateMap<AnswerItemDTO, AnswerItem>();
        }
    }
}
