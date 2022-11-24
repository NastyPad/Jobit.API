using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
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
    private readonly IRecruiterProfileRepository _recruiterProfileRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecruiterService(IRecruiterRepository recruiterRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IRecruiterProfileRepository recruiterProfileRepository)
    {
        _recruiterRepository = recruiterRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _recruiterProfileRepository = recruiterProfileRepository;
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
            //Register new user
            User newUserInsertion = new User(recruiter);
            await _userRepository.RegisterUserAsync(newUserInsertion);
            await _unitOfWork.CompleteAsync();
            
            //Set Recruiter Foreign Keys from User.
            recruiter.UserId = newUserInsertion.UserId;
            
            //Register new recruiter
            await _recruiterRepository.RegisterRecruiterAsync(recruiter);
            await _unitOfWork.CompleteAsync();
            
            //Creating new recruiter profile
            await GenerateRecruiterProfileAsync(recruiter.RecruiterId);
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
            //Deleting new recruiter profile
            var existingRecruiterProfile = await _recruiterProfileRepository.FindRecruiterProfileByRecruiterIdAsync(existingRecruiter.RecruiterId);
            _recruiterProfileRepository.DeleteRecruiterProfile(existingRecruiterProfile);
            await _unitOfWork.CompleteAsync();
            
            //Deleting new recruiter
            _recruiterRepository.DeleteRecruiterAsync(existingRecruiter);
            await _unitOfWork.CompleteAsync();
            
            //Deleting new user
            var existingUser = await _userRepository.FindUserByUserIdAsync(existingRecruiter.UserId);
            _userRepository.DeleteUser(existingUser);
            
            return new RecruiterResponse(existingRecruiter);
        }
        catch (Exception exception)
        {
            return new RecruiterResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<Object> GetRecruiterPublicData(long recruiterId)
    {
        //This recruiter must exist.
        var mustExistingRecruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(recruiterId);
        return new { username = mustExistingRecruiter.Username, firstname = mustExistingRecruiter.Firstname, lastname = mustExistingRecruiter.Lastname };
    }

    public async Task GenerateRecruiterProfileAsync(long recruiterId)
    {
        try
        {
            var userPublicData = await GetRecruiterPublicData(recruiterId);
            var username = userPublicData.GetType().GetProperty("username")!.GetValue(userPublicData, null)!.ToString();
            var firstname = userPublicData.GetType().GetProperty("firstname")!.GetValue(userPublicData, null)!.ToString();
            var lastname = userPublicData.GetType().GetProperty("lastname")!.GetValue(userPublicData, null)!.ToString();

            Console.WriteLine($"{username} - {firstname} - {lastname} - {recruiterId}");
            RecruiterProfile starterRecruiterProfile = new RecruiterProfile(recruiterId, username, firstname, lastname);
            
            await _recruiterProfileRepository.AddRecruiterProfileAsync(starterRecruiterProfile);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new ApplicationException();
        }
    }
}