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

        ////[HttpGet("pending")]
        ////public async Task<IActionResult> GetPending([FromQuery] string tenant, CancellationToken cancellationToken = default)
        ////{
        ////    var query = new (tenant);
        ////    var calls = await _mediator.Send<>(query, cancellationToken);
        ////    return Ok(calls);
        ////}

        ////[HttpGet("processed")]
        ////public async Task<IActionResult> GetProcessed([FromQuery] string tenant, CancellationToken cancellationToken = default)
        ////{
        ////    var query = new (tenant);
        ////    var calls = await _mediator.Send(query, cancellationToken);
        ////    return Ok(calls);
        ////}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCallRequest createCallRequest, CancellationToken cancellationToken = default)
        {
            var command = new CreateCallCommand(createCallRequest);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPatch("process")]
        public async Task<IActionResult> ProcessCall(ProcessCallRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }

        ////[HttpPatch("additionalInfo")]
        ////public async Task<IActionResult> UpdateCallWithAdditionalInfo()
        ////{
        ////    await _mediator.Send();
        ////    return Ok();
        ////}
    }
}
