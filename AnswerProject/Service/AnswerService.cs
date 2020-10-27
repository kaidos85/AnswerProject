using AnswerProject.DTO;
using AnswerProject.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Service
{
    public class AnswerService: BaseService
    {
        public AnswerService(AnswerContext ctx, ILogger<AnswerService> logger, IMapper mapper)
            : base(ctx, logger, mapper)
        {

        }

        public Task<List<AnswerDTO>> GetList()
        {
            return GetItems<AnswerDTO, Answer>();
        }

        public async Task<bool> SaveData(IEnumerable<AnswerItemDTO> items)
        {
            var answerItems = mapper.Map<List<AnswerItem>>(items);
            var answer = new Answer
            {
                UserName = answerItems?.FirstOrDefault(c => c.Question_Id == 1)?.Value,
                ADate = DateTime.Now,
                AnswerItems = answerItems
            };
            ctx.Answers.Add(answer);
            return await ctx.SaveChangesAsync() > 0;
        }
    }
}
