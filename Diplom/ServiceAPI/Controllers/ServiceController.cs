using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.ServiceHandlers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("callers")]
        public async Task<IActionResult> GetCallers(CancellationToken cancellation = default)
        {
            var query = new GetCallersQuery(Guid.Empty);
            var callers = await _mediator.Send(query, cancellation);
            return Ok(callers);
        }

        [HttpGet("diagnosis")]
        public async Task<IActionResult> GetDiagnosis(CancellationToken cancellation = default)
        {
            var query = new GetDiagnosisQuery(Guid.Empty);
            var diagnosies = await _mediator.Send(query, cancellation);
            return Ok(diagnosies);
        }

        [HttpGet("streets")]
        public async Task<IActionResult> GetStreets(CancellationToken cancellationToken = default)
        {
            var query = new GetStreetsQuery(Guid.Empty);
            var streets = await _mediator.Send(query, cancellationToken);
            return Ok(streets);
        }

        [HttpGet("places")]
        public async Task<IActionResult> GetPlaces(CancellationToken cancellationToken = default)
        {
            var query = new GetPlacesQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("results")]
        public async Task<IActionResult> GetResults(CancellationToken cancellationToken = default)
        {
            var query = new GetResultsQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
