using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmployersControllerBase : ControllerBase
{
    protected readonly IEmployersService _service;

    public EmployersControllerBase(IEmployersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Employer
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Employer>> CreateEmployer(EmployerCreateInput input)
    {
        var employer = await _service.CreateEmployer(input);

        return CreatedAtAction(nameof(Employer), new { id = employer.Id }, employer);
    }

    /// <summary>
    /// Delete one Employer
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmployer([FromRoute()] EmployerWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteEmployer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Employers
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Employer>>> Employers(
        [FromQuery()] EmployerFindManyArgs filter
    )
    {
        return Ok(await _service.Employers(filter));
    }

    /// <summary>
    /// Meta data about Employer records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmployersMeta(
        [FromQuery()] EmployerFindManyArgs filter
    )
    {
        return Ok(await _service.EmployersMeta(filter));
    }

    /// <summary>
    /// Get one Employer
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Employer>> Employer(
        [FromRoute()] EmployerWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Employer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Employer
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmployer(
        [FromRoute()] EmployerWhereUniqueInput uniqueId,
        [FromQuery()] EmployerUpdateInput employerUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmployer(uniqueId, employerUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
