using JobPostingService.Infrastructure;

namespace JobPostingService.APIs;

public class JobsService : JobsServiceBase
{
    public JobsService(JobPostingServiceDbContext context)
        : base(context) { }
}
