using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs;

[ApiController()]
public class EmployersController : EmployersControllerBase
{
    public EmployersController(IEmployersService service)
        : base(service) { }
}
