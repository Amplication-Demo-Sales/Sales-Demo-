using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[ApiController()]
public class ApplicantsController : ApplicantsControllerBase
{
    public ApplicantsController(IApplicantsService service)
        : base(service) { }
}
