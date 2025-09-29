using JobPostingService.APIs.Dtos;
using JobPostingService.Infrastructure.Models;

namespace JobPostingService.APIs.Extensions;

public static class ApplicantsExtensions
{
    public static Applicant ToDto(this ApplicantDbModel model)
    {
        return new Applicant
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ApplicantDbModel ToModel(
        this ApplicantUpdateInput updateDto,
        ApplicantWhereUniqueInput uniqueId
    )
    {
        var applicant = new ApplicantDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            applicant.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            applicant.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return applicant;
    }
}
