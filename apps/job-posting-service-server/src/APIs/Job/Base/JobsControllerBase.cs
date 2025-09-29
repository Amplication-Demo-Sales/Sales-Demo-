using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class JobsControllerBase : ControllerBase
{
    protected readonly IJobsService _service;

    public JobsControllerBase(IJobsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Job
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Job>> CreateJob(JobCreateInput input)
    {
        var job = await _service.CreateJob(input);

        return CreatedAtAction(nameof(Job), new { id = job.Id }, job);
    }

    /// <summary>
    /// Delete one Job
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteJob([FromRoute()] JobWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteJob(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Jobs
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Job>>> Jobs([FromQuery()] JobFindManyArgs filter)
    {
        return Ok(await _service.Jobs(filter));
    }

    /// <summary>
    /// Meta data about Job records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> JobsMeta([FromQuery()] JobFindManyArgs filter)
    {
        return Ok(await _service.JobsMeta(filter));
    }

    /// <summary>
    /// Get one Job
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Job>> Job([FromRoute()] JobWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Job(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Job
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateJob(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromQuery()] JobUpdateInput jobUpdateDto
    )
    {
        try
        {
            await _service.UpdateJob(uniqueId, jobUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
