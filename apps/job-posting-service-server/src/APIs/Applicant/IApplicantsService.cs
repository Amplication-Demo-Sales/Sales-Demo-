using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;

namespace JobPostingService.APIs;

public interface IApplicantsService
{
    /// <summary>
    /// Create one Applicant
    /// </summary>
    public Task<Applicant> CreateApplicant(ApplicantCreateInput applicant);

    /// <summary>
    /// Delete one Applicant
    /// </summary>
    public Task DeleteApplicant(ApplicantWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Applicants
    /// </summary>
    public Task<List<Applicant>> Applicants(ApplicantFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Applicant records
    /// </summary>
    public Task<MetadataDto> ApplicantsMeta(ApplicantFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Applicant
    /// </summary>
    public Task<Applicant> Applicant(ApplicantWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Applicant
    /// </summary>
    public Task UpdateApplicant(ApplicantWhereUniqueInput uniqueId, ApplicantUpdateInput updateDto);
}
