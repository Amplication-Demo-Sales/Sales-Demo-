using JobPostingService.APIs.Dtos;
using JobPostingService.Infrastructure.Models;

namespace JobPostingService.APIs.Extensions;

public static class EmployersExtensions
{
    public static Employer ToDto(this EmployerDbModel model)
    {
        return new Employer
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmployerDbModel ToModel(
        this EmployerUpdateInput updateDto,
        EmployerWhereUniqueInput uniqueId
    )
    {
        var employer = new EmployerDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            employer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            employer.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return employer;
    }
}
