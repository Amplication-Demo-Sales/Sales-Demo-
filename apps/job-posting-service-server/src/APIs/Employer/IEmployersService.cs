using JobPostingService.APIs.Common;
using JobPostingService.APIs.Dtos;

namespace JobPostingService.APIs;

public interface IEmployersService
{
    /// <summary>
    /// Create one Employer
    /// </summary>
    public Task<Employer> CreateEmployer(EmployerCreateInput employer);

    /// <summary>
    /// Delete one Employer
    /// </summary>
    public Task DeleteEmployer(EmployerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Employers
    /// </summary>
    public Task<List<Employer>> Employers(EmployerFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Employer records
    /// </summary>
    public Task<MetadataDto> EmployersMeta(EmployerFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Employer
    /// </summary>
    public Task<Employer> Employer(EmployerWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Employer
    /// </summary>
    public Task UpdateEmployer(EmployerWhereUniqueInput uniqueId, EmployerUpdateInput updateDto);
}
