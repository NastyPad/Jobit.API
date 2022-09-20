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
    private readonly IMapper _mapper;

    public JobService(IJobRepository jobRepository, ICompanyRepository companyRepository,IUnitOfWork unitOfWork, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _jobRepository = jobRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Job>> ListJobsAsync()
    {
        var jobs = await _jobRepository.ListJobsAsync();
        jobs.ToList().ForEach(
             job => job.Company =  _companyRepository.FindByCompanyIdAsync(job.CompanyId).Result
             );
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

    public async Task<JobResponse> AddJobAsync(Job newJob)
    {
        try
        {
            await _jobRepository.AddJobAsync(newJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(newJob);
        }
        catch (Exception exception)
        {
            return new JobResponse($"An error has occurred while trying to add new job: {exception.Message}");
        }
    }

    public async Task<JobResponse> UpdateJobAsync(long jobId, Job updateJob)
    {
        var existingJob = await _jobRepository.FindByJobIdAsync(jobId);
        if (existingJob == null)
            return new JobResponse("Job does not exist.");
        
        existingJob.Available = updateJob.Available;
        existingJob.Description = updateJob.Description;
        existingJob.Salary = updateJob.Salary;
        existingJob.CompanyId = updateJob.CompanyId;
        existingJob.JobName = updateJob.JobName;
        
        try
        {
            _jobRepository.UpdateJobAsync(existingJob);
            await _unitOfWork.CompleteAsync();
            return new JobResponse(updateJob);
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