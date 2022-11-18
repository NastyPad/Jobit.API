using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class CareerService : ICareerService
{
    private readonly ICareerRepository _careerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CareerService(ICareerRepository careerRepository, IUnitOfWork unitOfWork)
    {
        _careerRepository = careerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Career>> ListAllCareersAsync()
    {
        return await _careerRepository.ListAllCareersAsync();
    }

    public async Task<CareerResponse> FindCareerByCareerIdAsync(long careerId)
    {
        var existingCareer = await _careerRepository.FindCareerByCareerIdAsync(careerId);
        if (existingCareer == null)
            return new CareerResponse("Career does not exist");
        return new CareerResponse(existingCareer);
    }

    public async Task<CareerResponse> AddCareerAsync(Career newCareer)
    {
        try
        {
            await _careerRepository.AddCareerAsync(newCareer);
            await _unitOfWork.CompleteAsync();
            return new CareerResponse(newCareer);
        }
        catch (Exception exception)
        {
            return new CareerResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<CareerResponse> UpdateCareerAsync(long careerId, Career updatedCareer)
    {
        var existingCareer = await _careerRepository.FindCareerByCareerIdAsync(careerId);
        if (existingCareer == null)
            return new CareerResponse("Career does not exist");

        existingCareer.SetCareer(updatedCareer);
        
        try
        {
            _careerRepository.UpdateCareerAsync(existingCareer);
            await _unitOfWork.CompleteAsync();
            return new CareerResponse(existingCareer);
        }
        catch (Exception exception)
        {
            return new CareerResponse($"An error has ocurred {exception.Message}");
        }
    }

    public async Task<CareerResponse> DeleteCareerAsync(long careerId)
    {
        var existingCareer = await _careerRepository.FindCareerByCareerIdAsync(careerId);
        if (existingCareer == null)
            return new CareerResponse("Career does not exist");

        try
        {
            _careerRepository.DeleteCareerAsync(existingCareer);
            await _unitOfWork.CompleteAsync();
            return new CareerResponse(existingCareer);
        }
        catch (Exception exception)
        {
            return new CareerResponse($"An error has ocurred {exception.Message}");
        }
    }
}