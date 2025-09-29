using JobPostingService.APIs.Dtos;
using JobPostingService.Infrastructure.Models;

namespace JobPostingService.APIs.Extensions;

public static class JobsExtensions
{
    public static Job ToDto(this JobDbModel model)
    {
        return new Job
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static JobDbModel ToModel(this JobUpdateInput updateDto, JobWhereUniqueInput uniqueId)
    {
        var job = new JobDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            job.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            job.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return job;
    }
}
