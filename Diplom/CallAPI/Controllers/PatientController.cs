using Ambulance.Domain.Models.Patients;
using CallAPI.Patients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatien([FromQuery] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetPatientQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdatePatienRequest request, CancellationToken cancellationToken = default)
        {
            var query = new UpdatePatientQuery(request);
            await _mediator.Send(query, cancellationToken);
            return Ok();
        }
    }
}
