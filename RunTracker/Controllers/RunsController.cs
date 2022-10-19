using Microsoft.AspNetCore.Mvc;
using RunTracker.Contracts.Run;
using RunTracker.Models;
using RunTracker.Services.Runs;
using ErrorOr;

namespace RunTracker.Controllers;

public class RunsController : ApiController
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
        ErrorOr<Created> createRunResult = _runService.CreateRun(run);

        if (createRunResult.IsError)
        {
            return Problem(createRunResult.Errors);
        }
        
        return CreatedAtAction(
            nameof(GetRun),
            new { id = run.Id },
            MapRunToRunResponse(run));
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetRun(Guid id)
    {
        ErrorOr<Run> getRunResult = _runService.GetRun(id);
        
        if (getRunResult.IsError)
        {
            return NotFound();
        }
        
        Run run = getRunResult.Value;
        
        return getRunResult.Match(
            run => Ok(MapRunToRunResponse(run)),
            errors => Problem(errors));
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
        ErrorOr<Deleted> deleteResult = _runService.DeleteRun(id);

        return deleteResult.Match(
            Deleted => NoContent(),
            errors => Problem(errors)
            );

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
    
    private static RunResponse MapRunToRunResponse(Run run)
    {
        return new RunResponse(run.Id, run.Name, run.Description, run.Date,
            run.Duration, run.Distance, run.AverageSpeed);
    }
}