using JobPostingService.Infrastructure;

namespace JobPostingService.APIs;

public class ApplicantsService : ApplicantsServiceBase
{
    public ApplicantsService(JobPostingServiceDbContext context)
        : base(context) { }
}
