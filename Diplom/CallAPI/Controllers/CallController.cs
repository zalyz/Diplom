using Ambulance.Domain.Models.Call;
using CallAPI.CreateCall;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            return (IActionResult)Task.CompletedTask;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateCallRequest createCallRequest, CancellationToken cancellationToken = default)
        {
            var command = new CreateCallCommand(createCallRequest);
            var result = await _mediator.Send(command, cancellationToken);
            var link = Url.ActionLink(nameof(Get), "Call", new
            {
                id = result.ToString(),
            });
            var address = new UriBuilder(new Uri(link)).Uri;
            return Created(address, result);
        }

        [HttpPatch]
        public Task<IActionResult> Update()
        {
            return (Task<IActionResult>)Task.CompletedTask;
        }
    }
}
