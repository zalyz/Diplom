using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Employee;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("doktors")]
        public async Task<IActionResult> GetDoktors(CancellationToken cancellationToken = default)
        {
            var query = new GetDoktorsQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("assistants")]
        public async Task<IActionResult> GetMedicalAssistants(CancellationToken cancellationToken = default)
        {
            var query = new GetAssistantsQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("ordirlies")]
        public async Task<IActionResult> GetOrderlies(CancellationToken cancellationToken = default)
        {
            var query = new GetOrderliesQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetDrivers(CancellationToken cancellationToken = default)
        {
            var query = new GetDriversQuery(Guid.Empty);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
