using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatisticsAPI.Calls;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ageDiagnosis")]
        public async Task<IActionResult> GetAgeDiagnosis(CancellationToken cancellationToken = default)
        {
            var request = new AgeDiagnosisRequest(Guid.Empty);
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
    }
}
