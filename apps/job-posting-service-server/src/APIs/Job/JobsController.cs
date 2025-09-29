using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[ApiController()]
public class JobsController : JobsControllerBase
{
    public JobsController(IJobsService service)
        : base(service) { }
}
