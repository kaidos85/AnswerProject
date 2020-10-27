using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerProject.DTO;
using AnswerProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnswerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        AnswerService service;

        public AnswerController(AnswerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await service.GetList());
        }

        [HttpPost]
        public async Task<IActionResult> SaveData(IEnumerable<AnswerItemDTO> items)
        {
            return Ok(await service.SaveData(items));
        }        
    }
}
