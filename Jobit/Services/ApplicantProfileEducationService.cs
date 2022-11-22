using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class ApplicantProfileEducationService : IApplicantProfileEducationService
{
    private readonly IApplicantProfileEducationRepository _applicantProfileEducationRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly ICareerRepository _careerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantProfileEducationService(IApplicantProfileEducationRepository applicantProfileEducationRepository,
        IEducationRepository educationRepository, ICareerRepository careerRepository, IUnitOfWork unitOfWork)
    {
        _applicantProfileEducationRepository = applicantProfileEducationRepository;
        _educationRepository = educationRepository;
        _careerRepository = careerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ApplicantProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId)
    {
        var userProfileEducations =
            await _applicantProfileEducationRepository.ListUserProfileEducationsByUserIdAsync(userId);
        userProfileEducations.ToList().ForEach((userProfileEducation) =>
            { 
                SetUserProfileEducationObjects(userProfileEducation);
            }
        );
        return userProfileEducations;
    }

    public async Task<UserProfileEducationResponse> FindUserProfileEducationByUserProfileEducationId(
        long userProfileEducationId)
    {
        var existingUserProfileEducation =
            await _applicantProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);
        if (existingUserProfileEducation != null)
            return new UserProfileEducationResponse("This user profile education does not exist.");

        await SetUserProfileEducationObjects(existingUserProfileEducation);

        return new UserProfileEducationResponse(existingUserProfileEducation);
    }

    public async Task<UserProfileEducationResponse> AddUserProfileEducationAsync(
        ApplicantProfileEducation newApplicantProfileEducation)
    {
        try
        {
            await _applicantProfileEducationRepository.AddUserProfileEducationAsync(newApplicantProfileEducation);
            await _unitOfWork.CompleteAsync();
            return new UserProfileEducationResponse(newApplicantProfileEducation);
        }
        catch (Exception exception)
        {
            return new UserProfileEducationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<UserProfileEducationResponse> UpdateUserProfileEducationAsync(long userProfileEducationId,
        ApplicantProfileEducation updatedApplicantProfileEducation)
    {
        var existingUserProfileEducation =
            await _applicantProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);

        existingUserProfileEducation.SetUserProfileEducation(updatedApplicantProfileEducation);

        try
        {
            _applicantProfileEducationRepository.UpdateUserProfileEducation(existingUserProfileEducation);
            await _unitOfWork.CompleteAsync();
            return new UserProfileEducationResponse(existingUserProfileEducation);
        }
        catch (Exception exception)
        {
            return new UserProfileEducationResponse($"An error has ocurred: {exception.Message}");
        }
    }

    public async Task<UserProfileEducationResponse> DeleteUserProfileEducationAsync(long userProfileEducationId)
    {
        var existingUserProfileEducation =
            await _applicantProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);
        if (existingUserProfileEducation == null)
            return new UserProfileEducationResponse("This user profile education does not exist.");
        try
        {
            _applicantProfileEducationRepository.DeleteUserProfileEducation(existingUserProfileEducation);
            await _unitOfWork.CompleteAsync();
            return new UserProfileEducationResponse(existingUserProfileEducation);
        }
        catch (Exception exception)
        {
            return new UserProfileEducationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public Task SetUserProfileEducationObjects(ApplicantProfileEducation toSetApplicantProfileEducation)
    {
        toSetApplicantProfileEducation.Career =
            _careerRepository.FindCareerByCareerIdAsync(toSetApplicantProfileEducation.CareerId).Result;
        toSetApplicantProfileEducation.Education = _educationRepository
            .FindEducationByInstitutionIdAsync(toSetApplicantProfileEducation.EducationId).Result;
        return Task.CompletedTask;
    }
}