using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[ApiController()]
public class JobApplicationsController : JobApplicationsControllerBase
{
    public JobApplicationsController(IJobApplicationsService service)
        : base(service) { }
}
