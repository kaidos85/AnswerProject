using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnswerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        QuestionService service;

        public QuestionController(QuestionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await service.GetList());
        }
    }
}
