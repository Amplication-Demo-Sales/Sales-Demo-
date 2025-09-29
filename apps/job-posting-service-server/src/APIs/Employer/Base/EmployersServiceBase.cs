using JobPostingService.APIs;
using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;
using JobPostingService.APIs.Errors;
using JobPostingService.APIs.Extensions;
using JobPostingService.Infrastructure;
using JobPostingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPostingService.APIs;

public abstract class EmployersServiceBase : IEmployersService
{
    protected readonly JobPostingServiceDbContext _context;

    public EmployersServiceBase(JobPostingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Employer
    /// </summary>
    public async Task<Employer> CreateEmployer(EmployerCreateInput createDto)
    {
        var employer = new EmployerDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            employer.Id = createDto.Id;
        }

        _context.Employers.Add(employer);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EmployerDbModel>(employer.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Employer
    /// </summary>
    public async Task DeleteEmployer(EmployerWhereUniqueInput uniqueId)
    {
        var employer = await _context.Employers.FindAsync(uniqueId.Id);
        if (employer == null)
        {
            throw new NotFoundException();
        }

        _context.Employers.Remove(employer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Employers
    /// </summary>
    public async Task<List<Employer>> Employers(EmployerFindManyArgs findManyArgs)
    {
        var employers = await _context
            .Employers.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return employers.ConvertAll(employer => employer.ToDto());
    }

    /// <summary>
    /// Meta data about Employer records
    /// </summary>
    public async Task<MetadataDto> EmployersMeta(EmployerFindManyArgs findManyArgs)
    {
        var count = await _context.Employers.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Employer
    /// </summary>
    public async Task<Employer> Employer(EmployerWhereUniqueInput uniqueId)
    {
        var employers = await this.Employers(
            new EmployerFindManyArgs { Where = new EmployerWhereInput { Id = uniqueId.Id } }
        );
        var employer = employers.FirstOrDefault();
        if (employer == null)
        {
            throw new NotFoundException();
        }

        return employer;
    }

    /// <summary>
    /// Update one Employer
    /// </summary>
    public async Task UpdateEmployer(
        EmployerWhereUniqueInput uniqueId,
        EmployerUpdateInput updateDto
    )
    {
        var employer = updateDto.ToModel(uniqueId);

        _context.Entry(employer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Employers.Any(e => e.Id == employer.Id))
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
