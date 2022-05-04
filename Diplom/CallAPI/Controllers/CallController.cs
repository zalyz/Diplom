using Ambulance.Domain.Models.Call;
using CallAPI.Call;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : Controller
    {
        private readonly IMediator _mediator;

        public CallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("accepted")]
        public async Task<IActionResult> GetAccepted(CancellationToken cancellationToken = default)
        {
            var query = new GetAcceptedCallsQuery(Guid.Empty);
            var calls = await _mediator.Send(query, cancellationToken);
            return Ok(calls);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending(CancellationToken cancellationToken = default)
        {
            var query = new GetPendingCallQuery(Guid.Empty);
            var calls = await _mediator.Send(query, cancellationToken);
            return Ok(calls);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCallRequest createCallRequest, CancellationToken cancellationToken = default)
        {
            var command = new CreateCallCommand(createCallRequest);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPatch("process")]
        public async Task<IActionResult> ProcessCall(ProcessCallRequest request, CancellationToken cancellationToken = default)
        {
            var command = new ProcessCallCommand(request);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
