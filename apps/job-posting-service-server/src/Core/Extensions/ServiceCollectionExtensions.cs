using JobPostingService.APIs;

namespace JobPostingService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicantsService, ApplicantsService>();
        services.AddScoped<IEmployersService, EmployersService>();
        services.AddScoped<IJobsService, JobsService>();
        services.AddScoped<IJobApplicationsService, JobApplicationsService>();
    }
}
