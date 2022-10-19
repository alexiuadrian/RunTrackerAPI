using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace RunTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase     // base controller for all API controllers
{
    protected IActionResult Problem(List<Error> errors)
    {
        // getting the first error (TEST ONLY)
        var firstError = errors[0];

        // status code from the first error depending on the type
        int? statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
        
        // creating the problem details object
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}