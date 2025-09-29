using JobPostingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPostingService.Infrastructure;

public class JobPostingServiceDbContext : DbContext
{
    public JobPostingServiceDbContext(DbContextOptions<JobPostingServiceDbContext> options)
        : base(options) { }

    public DbSet<JobDbModel> Jobs { get; set; }

    public DbSet<EmployerDbModel> Employers { get; set; }

    public DbSet<ApplicantDbModel> Applicants { get; set; }

    public DbSet<JobApplicationDbModel> JobApplications { get; set; }
}
