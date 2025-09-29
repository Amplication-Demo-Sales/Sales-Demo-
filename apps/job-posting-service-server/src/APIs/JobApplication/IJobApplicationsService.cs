using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;

namespace JobPostingService.APIs;

public interface IJobApplicationsService
{
    /// <summary>
    /// Create one JobApplication
    /// </summary>
    public Task<JobApplication> CreateJobApplication(JobApplicationCreateInput jobapplication);

    /// <summary>
    /// Delete one JobApplication
    /// </summary>
    public Task DeleteJobApplication(JobApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many JobApplications
    /// </summary>
    public Task<List<JobApplication>> JobApplications(JobApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about JobApplication records
    /// </summary>
    public Task<MetadataDto> JobApplicationsMeta(JobApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one JobApplication
    /// </summary>
    public Task<JobApplication> JobApplication(JobApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one JobApplication
    /// </summary>
    public Task UpdateJobApplication(
        JobApplicationWhereUniqueInput uniqueId,
        JobApplicationUpdateInput updateDto
    );
}
