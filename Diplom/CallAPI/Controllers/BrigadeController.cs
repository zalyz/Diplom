using Ambulance.Domain.Models.Brigade;
using CallAPI.Brigade;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrigadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrigadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Возвращает список бригад с их вызовами (могут быть пустыми)
        [HttpGet]
        public async Task<IActionResult> GetBrigades(CancellationToken cancellationToken = default)
        {
            var query = new GetBrigadeQuery(Guid.Empty);
            var brigades = await _mediator.Send(query, cancellationToken);
            return Ok(brigades);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBrigade([FromBody]CreateBrigadeRequest request, CancellationToken cancellationToken = default)
        {
            var command = new CreateBrigadeCommand(request);
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> DeleteBrigade([FromBody]int brigadeId, CancellationToken cancellationToken = default)
        {
            var command = new DeleteBrigadeCommand(brigadeId);
            _ = await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        // Возвращает обновленную бригаду, для замены в списоке на компе
        [HttpPatch("assignCall")]
        public async Task<IActionResult> AssignCallToBrigade([FromBody] AssignCallRequest request, CancellationToken cancellationToken = default)
        {
            var query = new AssignCallCommand(request);
            _ = await _mediator.Send(query, cancellationToken);
            return Ok();
        }

        [HttpPatch("release")]
        public async Task<IActionResult> ReleaseBrigade([FromBody]int brigadeId, CancellationToken cancellationToken = default)
        {
            var command = new ReleaseBrigadeCommand(brigadeId);
            _ = await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPatch("return")]
        public async Task<IActionResult> ReturnCall([FromBody]int brigadeId, CancellationToken cancellationToken = default)
        {
            var command = new ReturnCallCommand(brigadeId);
            _ = await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
