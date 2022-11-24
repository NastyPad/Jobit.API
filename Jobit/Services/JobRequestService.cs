using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class JobRequestService : IJobRequestService
{
    private readonly IJobRequestRepository _jobRequestRepository;
    private readonly IPostJobRepository _postJobRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public JobRequestService(IJobRequestRepository jobRequestRepository, IUserRepository userRepository, IPostJobRepository postJobRepository, IMapper mapper, IUnitOfWork unitOfWork )
    {
        _jobRequestRepository = jobRequestRepository;
        _userRepository = userRepository;
        _postJobRepository = postJobRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<JobRequest>> ListJobRequestsAsync()
    {
        var jobRequests = await _jobRequestRepository.ListJobRequestAsync();
        jobRequests.ToList().ForEach(jobRequest =>
        {
            jobRequest.PostJob = _postJobRepository.FindByPostJobIdAsync(jobRequest.PostJobId).Result;
            //jobRequest.Applicant = _userRepository.FindUserByUserIdAsync(jobRequest.AppplicantId).Result;
        });
        return jobRequests.AsEnumerable();
    }

    public async Task<JobRequestResponse> FindJobRequestByRequestId(long requestId)
    {
        var existingJobRequest = await _jobRequestRepository.FindJobRequestByRequestIdAsync(requestId);
        if (existingJobRequest == null)
            return new JobRequestResponse("Job request does not exist.");
        try
        {
            return new JobRequestResponse(existingJobRequest);
        }
        catch (Exception exception)
        {
            return new JobRequestResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<JobRequestResponse> AddJobRequestAsync(JobRequest jobRequest)
    {
        try
        {
            await _jobRequestRepository.AddJobRequestAsync(jobRequest);
            await _unitOfWork.CompleteAsync();
            return new JobRequestResponse(jobRequest);
        }
        catch (Exception exception)
        {
            return new JobRequestResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<JobRequestResponse> UpdateJobRequestAsync(long requestId, JobRequest jobRequest)
    {
        var existingJobRequest = await _jobRequestRepository.FindJobRequestByRequestIdAsync(requestId);
        if (existingJobRequest == null)
            return new JobRequestResponse("Job request does not exist.");
        
        existingJobRequest.PostJobId = jobRequest.PostJobId;
        existingJobRequest.ApplicantId = jobRequest.ApplicantId;
        
        try
        {
            _jobRequestRepository.UpdateJobRequest(jobRequest);
            await _unitOfWork.CompleteAsync();
            return new JobRequestResponse(jobRequest);
        }
        catch (Exception exception)
        {
            return new JobRequestResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<JobRequestResponse> DeleteJobRequestAsync(long requestId)
    {
        var existingJobRequest = await _jobRequestRepository.FindJobRequestByRequestIdAsync(requestId);
        if (existingJobRequest == null)
            return new JobRequestResponse("Job request does not exist.");

        try
        {
            _jobRequestRepository.DeleteJobRequest(existingJobRequest);
            await _unitOfWork.CompleteAsync();
            return new JobRequestResponse(existingJobRequest);
        }
        catch (Exception exception)
        {
            return new JobRequestResponse($"An error has occurred while trying to delete this job: {exception.Message}");
        }
    }
    
}