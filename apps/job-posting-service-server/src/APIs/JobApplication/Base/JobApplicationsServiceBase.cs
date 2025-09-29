using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using JobPostingService.APIs.Extensions;
using JobPostingService.Infrastructure;
using JobPostingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPostingService.APIs;

public abstract class JobApplicationsServiceBase : IJobApplicationsService
{
    protected readonly JobPostingServiceDbContext _context;

    public JobApplicationsServiceBase(JobPostingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one JobApplication
    /// </summary>
    public async Task<JobApplication> CreateJobApplication(JobApplicationCreateInput createDto)
    {
        var jobApplication = new JobApplicationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            jobApplication.Id = createDto.Id;
        }

        _context.JobApplications.Add(jobApplication);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<JobApplicationDbModel>(jobApplication.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one JobApplication
    /// </summary>
    public async Task DeleteJobApplication(JobApplicationWhereUniqueInput uniqueId)
    {
        var jobApplication = await _context.JobApplications.FindAsync(uniqueId.Id);
        if (jobApplication == null)
        {
            throw new NotFoundException();
        }

        _context.JobApplications.Remove(jobApplication);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many JobApplications
    /// </summary>
    public async Task<List<JobApplication>> JobApplications(JobApplicationFindManyArgs findManyArgs)
    {
        var jobApplications = await _context
            .JobApplications.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return jobApplications.ConvertAll(jobApplication => jobApplication.ToDto());
    }

    /// <summary>
    /// Meta data about JobApplication records
    /// </summary>
    public async Task<MetadataDto> JobApplicationsMeta(JobApplicationFindManyArgs findManyArgs)
    {
        var count = await _context.JobApplications.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one JobApplication
    /// </summary>
    public async Task<JobApplication> JobApplication(JobApplicationWhereUniqueInput uniqueId)
    {
        var jobApplications = await this.JobApplications(
            new JobApplicationFindManyArgs
            {
                Where = new JobApplicationWhereInput { Id = uniqueId.Id }
            }
        );
        var jobApplication = jobApplications.FirstOrDefault();
        if (jobApplication == null)
        {
            throw new NotFoundException();
        }

        return jobApplication;
    }

    /// <summary>
    /// Update one JobApplication
    /// </summary>
    public async Task UpdateJobApplication(
        JobApplicationWhereUniqueInput uniqueId,
        JobApplicationUpdateInput updateDto
    )
    {
        var jobApplication = updateDto.ToModel(uniqueId);

        _context.Entry(jobApplication).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.JobApplications.Any(e => e.Id == jobApplication.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
