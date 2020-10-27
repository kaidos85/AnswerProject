using AnswerProject.DTO;
using AnswerProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Service
{
    public class QuestionService: BaseService
    {
        public QuestionService(AnswerContext ctx, ILogger<QuestionService> logger, IMapper mapper)
            : base(ctx, logger, mapper)
        {

        }

        public async Task<List<QuestionDTO>> GetList()
        {
            var questions = await ctx.Questions.ToListAsync();
            return mapper.Map<List<QuestionDTO>>(questions);
        }
    }
}
