using Microsoft.AspNetCore.Mvc;
using RunTracker.Contracts.Run;
using RunTracker.Models;
using RunTracker.Services.Runs;

namespace RunTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RunsController : ControllerBase
{
    private readonly IRunService _runService;

    public RunsController(IRunService runService)
    {
        _runService = runService;
    }

    [HttpPost]
    public IActionResult CreateRun(CreateRunRequest request)
    {
        Run run = new Run(Guid.NewGuid(), request.Name, request.Description, request.Date,
            request.Duration, request.Distance, request.AverageSpeed);
        
        // TODO: save the Run to the database
        _runService.CreateRun(run);
        
        RunResponse response = new RunResponse(run.Id, run.Name, run.Description, run.Date,
            run.Duration, run.Distance, run.AverageSpeed);

        return CreatedAtAction(
            nameof(GetRun),
            new { id = response.Id },
            response);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetRun(Guid id)
    {
        Run run = _runService.GetRun(id);
        return Ok(new RunResponse(run.Id, run.Name, run.Description, run.Date,
            run.Duration, run.Distance, run.AverageSpeed));
    }
    
    [HttpPost("{id:guid}")]
    public IActionResult UpdateRun(Guid id, UpsertRunRequest request)
    {
        Run run = new Run(id, request.Name, request.Description, request.Date,
            request.Duration, request.Distance, request.AverageSpeed);
        
        _runService.UpdateRun(run);
        
        // TODO: return 201 if the run was created, 204 if it was updated
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRun(Guid id)
    {
        _runService.DeleteRun(id);
        
        return NoContent();
    }
    
    [HttpGet]
    public IActionResult GetRuns()
    {
        Dictionary<Guid, Run> runs = _runService.GetRuns();
        List<RunResponse> Runs = new List<RunResponse>();
        for (int i = 0; i < runs.Count; i++)
        {
            Runs.Add(new RunResponse(runs.ElementAt(i).Value.Id, runs.ElementAt(i).Value.Name, runs.ElementAt(i).Value.Description, runs.ElementAt(i).Value.Date,
                runs.ElementAt(i).Value.Duration, runs.ElementAt(i).Value.Distance, runs.ElementAt(i).Value.AverageSpeed));
        }
        return Ok(new RunsResponse(Runs));
    }
}