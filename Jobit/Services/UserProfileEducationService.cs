using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class UserProfileEducationService : IUserProfileEducationService
{
    private readonly IUserProfileEducationRepository _userProfileEducationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileEducationService(IUserProfileEducationRepository userProfileEducationRepository,
        IUnitOfWork unitOfWork)
    {
        _userProfileEducationRepository = userProfileEducationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId)
    {
        return await _userProfileEducationRepository.ListUserProfileEducationsByUserIdAsync(userId);
    }

    public async Task<UserProfileEducationResponse> FindUserProfileEducationByUserProfileEducationId(
        long userProfileEducationId)
    {
        var existingUserProfileEducation =
            await _userProfileEducationRepository.FindUserProfileEducationByUserProfileEducationId(
                userProfileEducationId);
        if (existingUserProfileEducation != null)
            return new UserProfileEducationResponse("This user profile education does not exist.");
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
}