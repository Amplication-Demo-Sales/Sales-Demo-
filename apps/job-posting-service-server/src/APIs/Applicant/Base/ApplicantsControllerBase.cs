using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ApplicantsControllerBase : ControllerBase
{
    protected readonly IApplicantsService _service;

    public ApplicantsControllerBase(IApplicantsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Applicant
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Applicant>> CreateApplicant(ApplicantCreateInput input)
    {
        var applicant = await _service.CreateApplicant(input);

        return CreatedAtAction(nameof(Applicant), new { id = applicant.Id }, applicant);
    }

    /// <summary>
    /// Delete one Applicant
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteApplicant(
        [FromRoute()] ApplicantWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteApplicant(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Applicants
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Applicant>>> Applicants(
        [FromQuery()] ApplicantFindManyArgs filter
    )
    {
        return Ok(await _service.Applicants(filter));
    }

    /// <summary>
    /// Meta data about Applicant records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ApplicantsMeta(
        [FromQuery()] ApplicantFindManyArgs filter
    )
    {
        return Ok(await _service.ApplicantsMeta(filter));
    }

    /// <summary>
    /// Get one Applicant
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Applicant>> Applicant(
        [FromRoute()] ApplicantWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Applicant(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Applicant
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateApplicant(
        [FromRoute()] ApplicantWhereUniqueInput uniqueId,
        [FromQuery()] ApplicantUpdateInput applicantUpdateDto
    )
    {
        try
        {
            await _service.UpdateApplicant(uniqueId, applicantUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
