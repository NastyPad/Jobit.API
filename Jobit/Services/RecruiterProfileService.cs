using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class RecruiterProfileService : IRecruiterProfileService
{
    private readonly IRecruiterProfileRepository _recruiterProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecruiterProfileService(IRecruiterProfileRepository recruiterProfileRepository, IUnitOfWork unitOfWork)
    {
        _recruiterProfileRepository = recruiterProfileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RecruiterProfile>> ListRecruiterProfilesByRecruiterIdAsync()
    {
        return await _recruiterProfileRepository.ListRecruiterProfilesAsync();
    }

    public async Task<RecruiterProfileResponse> FindRecruiterProfileByRecruiterId(long recruiterId)
    {
        var existingRecruiterProfile = await _recruiterProfileRepository.FindRecruiterProfileByRecruiterIdAsync(recruiterId);
        if (existingRecruiterProfile == null)
            return new RecruiterProfileResponse("Recruiter profile does not exist.");
        return new RecruiterProfileResponse(existingRecruiterProfile);
    }

    public async Task<RecruiterProfileResponse> AddRecruiterProfileAsync(RecruiterProfile newRecruiterProfile)
    {
        try
        {
            await _recruiterProfileRepository.AddRecruiterProfileAsync(newRecruiterProfile);
            await _unitOfWork.CompleteAsync();
            return new RecruiterProfileResponse(newRecruiterProfile);
        }
        catch (Exception exception)
        {
            return new RecruiterProfileResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<RecruiterProfileResponse> UpdateRecruiterProfileAsync(long recruiterId, RecruiterProfile updatedRecruiterProfile)
    {
        var existingRecruiterProfile = await _recruiterProfileRepository.FindRecruiterProfileByRecruiterIdAsync(recruiterId);
        if (existingRecruiterProfile == null)
            return new RecruiterProfileResponse("Recruiter profile does not exist.");

        existingRecruiterProfile.SetRecruiterProfile(updatedRecruiterProfile);
        
        try
        {
            _recruiterProfileRepository.UpdateRecruiterProfile(updatedRecruiterProfile);
            await _unitOfWork.CompleteAsync();
            return new RecruiterProfileResponse(existingRecruiterProfile);
        }
        catch (Exception exception)
        {
            return new RecruiterProfileResponse($"An error has occurred: { exception.Message }");
        }
    }

    public async Task<RecruiterProfileResponse> DeleteRecruiterProfileAsync(long recruiterId)
    {
        throw new NotImplementedException();
    }

    public async Task SetRecruiterProfileObjects(RecruiterProfile toSetRecruiterProfile)
    {
        throw new NotImplementedException();
    }
}