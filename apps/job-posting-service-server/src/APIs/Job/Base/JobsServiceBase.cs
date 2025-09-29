using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using JobPostingService.APIs.Extensions;
using JobPostingService.Infrastructure;
using JobPostingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPostingService.APIs;

public abstract class JobsServiceBase : IJobsService
{
    protected readonly JobPostingServiceDbContext _context;

    public JobsServiceBase(JobPostingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Job
    /// </summary>
    public async Task<Job> CreateJob(JobCreateInput createDto)
    {
        var job = new JobDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            job.Id = createDto.Id;
        }

        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<JobDbModel>(job.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Job
    /// </summary>
    public async Task DeleteJob(JobWhereUniqueInput uniqueId)
    {
        var job = await _context.Jobs.FindAsync(uniqueId.Id);
        if (job == null)
        {
            throw new NotFoundException();
        }

        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Jobs
    /// </summary>
    public async Task<List<Job>> Jobs(JobFindManyArgs findManyArgs)
    {
        var jobs = await _context
            .Jobs.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return jobs.ConvertAll(job => job.ToDto());
    }

    /// <summary>
    /// Meta data about Job records
    /// </summary>
    public async Task<MetadataDto> JobsMeta(JobFindManyArgs findManyArgs)
    {
        var count = await _context.Jobs.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Job
    /// </summary>
    public async Task<Job> Job(JobWhereUniqueInput uniqueId)
    {
        var jobs = await this.Jobs(
            new JobFindManyArgs { Where = new JobWhereInput { Id = uniqueId.Id } }
        );
        var job = jobs.FirstOrDefault();
        if (job == null)
        {
            throw new NotFoundException();
        }

        return job;
    }

    /// <summary>
    /// Update one Job
    /// </summary>
    public async Task UpdateJob(JobWhereUniqueInput uniqueId, JobUpdateInput updateDto)
    {
        var job = updateDto.ToModel(uniqueId);

        _context.Entry(job).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Jobs.Any(e => e.Id == job.Id))
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
