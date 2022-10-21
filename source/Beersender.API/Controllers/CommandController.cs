using Beersender.API.Event_stream;
using Beersender.Domain;
using Beersender.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Beersender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly Command_router _router;
		private readonly EventContext eventContext;

		public CommandController(Command_router router, EventContext eventContext)
        {
            _router = router;
			this.eventContext = eventContext;
		}

        [HttpPost]
        public IActionResult PostCommand([FromBody] Command command)
        {
            _router.Handle_command(command);
            return Ok();
        }
    }
}
