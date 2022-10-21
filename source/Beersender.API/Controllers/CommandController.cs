using Beersender.Domain;
using Beersender.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Beersender.API.Controllers;

[Route("api/command")]
[ApiController]
public class CommandController : ControllerBase
{
    private readonly CommandRouter _router;

    public CommandController(CommandRouter router)
    {
        _router = router;
    }

    [HttpPost]
    public IActionResult PostCommand([FromBody] ICommand command)
    {
        _router.Handle_command(command);
        return Ok();
    }
}