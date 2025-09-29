using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;

namespace JobPostingService.APIs;

public interface IJobsService
{
    /// <summary>
    /// Create one Job
    /// </summary>
    public Task<Job> CreateJob(JobCreateInput job);

    /// <summary>
    /// Delete one Job
    /// </summary>
    public Task DeleteJob(JobWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Jobs
    /// </summary>
    public Task<List<Job>> Jobs(JobFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Job records
    /// </summary>
    public Task<MetadataDto> JobsMeta(JobFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Job
    /// </summary>
    public Task<Job> Job(JobWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Job
    /// </summary>
    public Task UpdateJob(JobWhereUniqueInput uniqueId, JobUpdateInput updateDto);
}
