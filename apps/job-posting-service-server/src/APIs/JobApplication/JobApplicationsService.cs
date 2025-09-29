using JobPostingService.Infrastructure;

namespace JobPostingService.APIs;

public class JobApplicationsService : JobApplicationsServiceBase
{
    public JobApplicationsService(JobPostingServiceDbContext context)
        : base(context) { }
}
