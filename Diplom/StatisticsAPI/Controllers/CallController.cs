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
            var bytes = await _mediator.Send(request, cancellationToken);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AgeDiagnosis.xlsx");
        }

        [HttpGet("diagnosisGender")]
        public async Task<IActionResult> GetDiagnosisGender(CancellationToken cancellationToken = default)
        {
            var query = new DiagnosisGenderQuery(Guid.Empty);
            var bytes = await _mediator.Send(query, cancellationToken);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AgeDiagnosis.xlsx");
        }

        [HttpGet("calls")]
        public async Task<IActionResult> GetCalls(CancellationToken cancellationToken = default)
        {
            var query = new GetCallsQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
