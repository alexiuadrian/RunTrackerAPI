using Microsoft.AspNetCore.Mvc;

namespace RunTracker.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    protected IActionResult Error()
    {
        return Problem();
    }
}