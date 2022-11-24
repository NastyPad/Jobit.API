using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class PostJobService : IPostJobService
{
    private readonly IPostJobRepository _postJobRepository;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostJobService(IPostJobRepository postJobRepository, ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork, IRecruiterRepository recruiterRepository)
    {
        _postJobRepository = postJobRepository;
        _unitOfWork = unitOfWork;
        _recruiterRepository = recruiterRepository;
    }

    public async Task<IEnumerable<PostJob>> ListPostJobsAsync()
    {
        var postJobs = await _postJobRepository.ListPostJobsAsync();
        postJobs.ToList().ForEach(async postJob =>
        {
            postJob.Recruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(postJob.RecruiterId);
        });
        return postJobs.AsEnumerable();
    }

    public async Task<JobResponse> FindByPostJobIdAsync(int jobId)
    {
        var existingJob = await _postJobRepository.FindByPostJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");
        existingJob.Recruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(existingJob.RecruiterId);
        return new JobResponse(existingJob);
    }

    public async Task<JobResponse> AddPostJobAsync(PostJob newPostJob)
    {
        try
        {
            await _postJobRepository.AddPostJobAsync(newPostJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(newPostJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to add new job: {exception.Message}");
        }
    }

    public async Task<JobResponse> UpdatePostJobAsync(long jobId, PostJob updatePostJob)
    {
        var existingJob = await _postJobRepository.FindByPostJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");

        existingJob.Available = updatePostJob.Available;
        existingJob.Description = updatePostJob.Description;
        existingJob.Salary = updatePostJob.Salary;
        existingJob.JobName = updatePostJob.JobName;

        try
        {
            _postJobRepository.UpdatePostJobAsync(existingJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(updatePostJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to update this job: {exception.Message}");
        }
    }

    public async Task<JobResponse> DeletePostJobAsync(long jobId)
    {
        var existingJob = await _postJobRepository.FindByPostJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");
        try
        {
            _postJobRepository.DeletePostJobAsync(existingJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(existingJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to delete this job: {exception.Message}");
        }
    }
}