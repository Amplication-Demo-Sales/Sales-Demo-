using JobPostingService.APIs.Dtos;
using JobPostingService.Infrastructure.Models;

namespace JobPostingService.APIs.Extensions;

public static class JobApplicationsExtensions
{
    public static JobApplication ToDto(this JobApplicationDbModel model)
    {
        return new JobApplication
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static JobApplicationDbModel ToModel(
        this JobApplicationUpdateInput updateDto,
        JobApplicationWhereUniqueInput uniqueId
    )
    {
        var jobApplication = new JobApplicationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            jobApplication.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            jobApplication.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return jobApplication;
    }
}
