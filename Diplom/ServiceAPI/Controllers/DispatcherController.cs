using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Dispatcher;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatcherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DispatcherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDispatcher([FromBody]int dispatcherId, CancellationToken cancellationToken = default)
        {
            var query = new GetDispatcherQuery(dispatcherId);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
