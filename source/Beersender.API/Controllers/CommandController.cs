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

        public CommandController(Command_router router)
        {
            _router = router;
        }

        [HttpPost]
        public IActionResult PostCommand([FromBody] Command command)
        {
            _router.Handle_command(command);
            return Ok();
        }
    }
}
