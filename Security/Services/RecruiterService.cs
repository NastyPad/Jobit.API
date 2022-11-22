using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Persistence.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Security.Services;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecruiterService(IRecruiterRepository recruiterRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _recruiterRepository = recruiterRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Recruiter>> ListAllRecruitersAsync()
    {
        return await _recruiterRepository.ListAllRecruiterAsync();
    }

    public async Task<RecruiterResponse> FindRecruiterByRecruiterIdAsync(long recruiterId)
    {
        var existingRecruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(recruiterId);
        if (existingRecruiter == null)
            return new RecruiterResponse("Recruiter does not exist");
        return new RecruiterResponse(existingRecruiter);
    }

    public async Task<RecruiterResponse> RegisterRecruiterAsync(RegisterRecruiterRequest newRecruiter)
    {
        var recruiter = _mapper.Map<RegisterRecruiterRequest, Recruiter>(newRecruiter);
        try
        {
            User newUserInsertion = new User(recruiter);
            await _userRepository.RegisterUserAsync(newUserInsertion);
            
            await _recruiterRepository.AddRecruiterAsync(recruiter);
            await _unitOfWork.CompleteAsync();
            
            return new RecruiterResponse(recruiter);
        }
        catch (Exception exception)
        {
            return new RecruiterResponse($"An error has ocurred: {exception.Message}");
        }
    }

    public async Task<RecruiterResponse> UpdateRecruiterAsync(long recruiterId, Recruiter newRecruiter)
    {
        var existingRecruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(recruiterId);
        if (existingRecruiter == null)
            return new RecruiterResponse("Recruiter does not exist");
        
        existingRecruiter.SetRecruiter(newRecruiter);
        
        try
        {
            _recruiterRepository.UpdateRecruiterAsync(existingRecruiter);
            await _unitOfWork.CompleteAsync();

            return new RecruiterResponse(existingRecruiter);
        }
        catch (Exception exception)
        {
            return new RecruiterResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<RecruiterResponse> DeleteRecruiterAsync(long recruiterId)
    {
        var existingRecruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(recruiterId);
        if (existingRecruiter == null)
            return new RecruiterResponse("Recruiter does not exist");
        try
        {
            _recruiterRepository.DeleteRecruiterAsync(existingRecruiter);
            await _unitOfWork.CompleteAsync();
            return new RecruiterResponse(existingRecruiter);
        }
        catch (Exception exception)
        {
            return new RecruiterResponse($"An error has occurred: {exception.Message}");
        }
    }
}