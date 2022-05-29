using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatisticsAPI.Brigades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrigadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrigadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("brigadeCalls")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var command = new BrigadesCallsRequest(Guid.Empty);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
