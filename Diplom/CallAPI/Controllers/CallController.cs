using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]int id)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {

        }

        [HttpPatch]
        public async Task<IActionResult> Update()
        {

        }
    }
}
