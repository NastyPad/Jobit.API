using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class UserProfileEducationService : IUserProfileEducationService
{
    private readonly IUserProfileEducationRepository _userProfileEducationRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly ICareerRepository _careerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileEducationService(IUserProfileEducationRepository userProfileEducationRepository,
        IEducationRepository educationRepository, ICareerRepository careerRepository, IUnitOfWork unitOfWork)
    {
        _userProfileEducationRepository = userProfileEducationRepository;
        _educationRepository = educationRepository;
        _careerRepository = careerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId)
    {
        var userProfileEducations =
            await _userProfileEducationRepository.ListUserProfileEducationsByUserIdAsync(userId);
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
            await _userProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);
        if (existingUserProfileEducation != null)
            return new UserProfileEducationResponse("This user profile education does not exist.");

        await SetUserProfileEducationObjects(existingUserProfileEducation);

        return new UserProfileEducationResponse(existingUserProfileEducation);
    }

    public async Task<UserProfileEducationResponse> AddUserProfileEducationAsync(
        UserProfileEducation newUserProfileEducation)
    {
        try
        {
            await _userProfileEducationRepository.AddUserProfileEducationAsync(newUserProfileEducation);
            await _unitOfWork.CompleteAsync();
            return new UserProfileEducationResponse(newUserProfileEducation);
        }
        catch (Exception exception)
        {
            return new UserProfileEducationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<UserProfileEducationResponse> UpdateUserProfileEducationAsync(long userProfileEducationId,
        UserProfileEducation updatedUserProfileEducation)
    {
        var existingUserProfileEducation =
            await _userProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);

        existingUserProfileEducation.SetUserProfileEducation(updatedUserProfileEducation);

        try
        {
            _userProfileEducationRepository.UpdateUserProfileEducation(existingUserProfileEducation);
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
            await _userProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);
        if (existingUserProfileEducation == null)
            return new UserProfileEducationResponse("This user profile education does not exist.");
        try
        {
            _userProfileEducationRepository.DeleteUserProfileEducation(existingUserProfileEducation);
            await _unitOfWork.CompleteAsync();
            return new UserProfileEducationResponse(existingUserProfileEducation);
        }
        catch (Exception exception)
        {
            return new UserProfileEducationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public Task SetUserProfileEducationObjects(UserProfileEducation toSetUserProfileEducation)
    {
        toSetUserProfileEducation.Career =
            _careerRepository.FindCareerByCareerIdAsync(toSetUserProfileEducation.CareerId).Result;
        toSetUserProfileEducation.Education = _educationRepository
            .FindEducationByInstitutionIdAsync(toSetUserProfileEducation.EducationId).Result;
        return Task.CompletedTask;
    }
}