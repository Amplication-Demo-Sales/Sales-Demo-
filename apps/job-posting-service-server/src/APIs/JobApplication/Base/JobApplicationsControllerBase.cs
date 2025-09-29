using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class JobApplicationsControllerBase : ControllerBase
{
    protected readonly IJobApplicationsService _service;

    public JobApplicationsControllerBase(IJobApplicationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one JobApplication
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<JobApplication>> CreateJobApplication(
        JobApplicationCreateInput input
    )
    {
        var jobApplication = await _service.CreateJobApplication(input);

        return CreatedAtAction(
            nameof(JobApplication),
            new { id = jobApplication.Id },
            jobApplication
        );
    }

    /// <summary>
    /// Delete one JobApplication
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteJobApplication(
        [FromRoute()] JobApplicationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteJobApplication(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many JobApplications
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<JobApplication>>> JobApplications(
        [FromQuery()] JobApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.JobApplications(filter));
    }

    /// <summary>
    /// Meta data about JobApplication records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> JobApplicationsMeta(
        [FromQuery()] JobApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.JobApplicationsMeta(filter));
    }

    /// <summary>
    /// Get one JobApplication
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<JobApplication>> JobApplication(
        [FromRoute()] JobApplicationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.JobApplication(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one JobApplication
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateJobApplication(
        [FromRoute()] JobApplicationWhereUniqueInput uniqueId,
        [FromQuery()] JobApplicationUpdateInput jobApplicationUpdateDto
    )
    {
        try
        {
            await _service.UpdateJobApplication(uniqueId, jobApplicationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
