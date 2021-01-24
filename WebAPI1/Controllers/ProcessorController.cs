using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1.Events.StartProcessing;
using WebAPI1.Models;
using WebAPI1.Requests.StateRequest;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProcessorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Work work)
        {
            var result = await mediator.Send<Work>(new StartProcessingEvent
            {
                Work = work
            });
            return Ok(result);
        }

        [HttpGet("{id}/state")]
        public async Task<string> GetState(int id)
        {
            var work = await mediator.Send(new StateRequest() { WorkId = id });

            return work.Status.ToString();
        }
    }
}
