using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public JobService(IJobRepository jobRepository, ICompanyRepository companyRepository,IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _jobRepository = jobRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PostJob>> ListJobsAsync()
    {
        var jobs = await _jobRepository.ListJobsAsync();
        return jobs.AsEnumerable();
    }

    public async Task<JobResponse> FindByJobIdAsync(int jobId)
    {
        var existingJob = await _jobRepository.FindByJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");
        try
        {
            return new JobResponse(existingJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<JobResponse> AddJobAsync(PostJob newPostJob)
    {
        try
        {
            await _jobRepository.AddJobAsync(newPostJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(newPostJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to add new job: {exception.Message}");
        }
    }

    public async Task<JobResponse> UpdateJobAsync(long jobId, PostJob updatePostJob)
    {
        var existingJob = await _jobRepository.FindByJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");
        
        existingJob.Available = updatePostJob.Available;
        existingJob.Description = updatePostJob.Description;
        existingJob.Salary = updatePostJob.Salary;
        existingJob.JobName = updatePostJob.JobName;
        
        try
        {
            _jobRepository.UpdateJobAsync(existingJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(updatePostJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to update this job: {exception.Message}");
        }
    }

    public async Task<JobResponse> DeleteJobAsync(long jobId)
    {
        var existingJob = await _jobRepository.FindByJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");
        try
        {
            _jobRepository.DeleteJobAsync(existingJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(existingJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to delete this job: {exception.Message}");
        }
    }
}