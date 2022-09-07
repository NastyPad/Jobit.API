using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> ListUsersAsync()
    {
        return await _userRepository.ListUsersAsync();
    }

    public async Task<User> GetByUserIdAsync(int userId)
    {
        var user = await _userRepository.FindByUserIdAsync(userId);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterUserAsync(RegisterUserRequest registerUserRequest)
    {
        var user = _mapper.Map<User>(registerUserRequest);
        await _userRepository.AddAsync(user);
    }
    
    
}