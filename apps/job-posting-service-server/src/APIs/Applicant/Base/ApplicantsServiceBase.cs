using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using JobPostingService.APIs.Extensions;
using JobPostingService.Infrastructure;
using JobPostingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPostingService.APIs;

public abstract class ApplicantsServiceBase : IApplicantsService
{
    protected readonly JobPostingServiceDbContext _context;

    public ApplicantsServiceBase(JobPostingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Applicant
    /// </summary>
    public async Task<Applicant> CreateApplicant(ApplicantCreateInput createDto)
    {
        var applicant = new ApplicantDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            applicant.Id = createDto.Id;
        }

        _context.Applicants.Add(applicant);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ApplicantDbModel>(applicant.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Applicant
    /// </summary>
    public async Task DeleteApplicant(ApplicantWhereUniqueInput uniqueId)
    {
        var applicant = await _context.Applicants.FindAsync(uniqueId.Id);
        if (applicant == null)
        {
            throw new NotFoundException();
        }

        _context.Applicants.Remove(applicant);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Applicants
    /// </summary>
    public async Task<List<Applicant>> Applicants(ApplicantFindManyArgs findManyArgs)
    {
        var applicants = await _context
            .Applicants.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return applicants.ConvertAll(applicant => applicant.ToDto());
    }

    /// <summary>
    /// Meta data about Applicant records
    /// </summary>
    public async Task<MetadataDto> ApplicantsMeta(ApplicantFindManyArgs findManyArgs)
    {
        var count = await _context.Applicants.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Applicant
    /// </summary>
    public async Task<Applicant> Applicant(ApplicantWhereUniqueInput uniqueId)
    {
        var applicants = await this.Applicants(
            new ApplicantFindManyArgs { Where = new ApplicantWhereInput { Id = uniqueId.Id } }
        );
        var applicant = applicants.FirstOrDefault();
        if (applicant == null)
        {
            throw new NotFoundException();
        }

        return applicant;
    }

    /// <summary>
    /// Update one Applicant
    /// </summary>
    public async Task UpdateApplicant(
        ApplicantWhereUniqueInput uniqueId,
        ApplicantUpdateInput updateDto
    )
    {
        var applicant = updateDto.ToModel(uniqueId);

        _context.Entry(applicant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Applicants.Any(e => e.Id == applicant.Id))
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
