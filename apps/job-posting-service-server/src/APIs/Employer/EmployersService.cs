using JobPostingService.Infrastructure;

namespace JobPostingService.APIs;

public class EmployersService : EmployersServiceBase
{
    public EmployersService(JobPostingServiceDbContext context)
        : base(context) { }
}
