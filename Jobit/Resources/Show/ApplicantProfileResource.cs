using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Resources.Bases;

namespace Jobit.API.Jobit.Resources;

public class ApplicantProfileResource : ProfileBaseResource
{
    public IList<ApplicantProfileTechSkillResource> UserProfileTechSkills { get; set; }
    public IList<ApplicantProfileEducationResource> UserProfileEducations { get; set; }
}