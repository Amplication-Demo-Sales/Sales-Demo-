using JobPostingService.APIs.Common;
using JobPostingService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPostingService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ApplicantFindManyArgs : FindManyInput<Applicant, ApplicantWhereInput> { }
