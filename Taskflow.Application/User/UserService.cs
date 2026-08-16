using Taskflow.Application.User.DTO;
using Taskflow.Application.User.Mapper;
using Taskflow.Domain.Shared.Interfaces;
using Taskflow.Domain.User;

namespace Taskflow.Application.User;

public sealed class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserService
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<UserResponse> CreateUserAsync(RegisterRequest payload)
  {
    UserAggregate? existingUser = await _userRepository.GetByEmailAsync(payload.Email);

    if (existingUser is not null) throw new Exception("User already exists");

    Guid Id = Guid.NewGuid();
    // UserAggregate user = payload.ToAggregate(Id);
    UserAggregate user = UserAggregate.Create(
        Id,
        payload.Username,
        payload.Email,
        payload.Password
        );

    await _userRepository.AddAsync(user);
    await _unitOfWork.SaveChangesAsync();

    return user.ToResponse();
  }

  public async Task<UserResponse> LoginAsync(LoginRequest payload)
  {

    UserAggregate user = await _userRepository.GetByEmailAsync(payload.Email) ?? throw new Exception("User not found");
    if (!user.Password.VerifyPassword(payload.Password)) throw new Exception("Invalid password");

    return user.ToResponse();
  }

  public async Task<UserResponse> GetByEmailAsync(string email)
  {
    UserAggregate user = await _userRepository.GetByEmailAsync(email) ?? throw new Exception("User not found");
    return user.ToResponse();
  }

  public async Task<UserResponse> GetByIdAsync(Guid id)
  {
    UserAggregate user = await _userRepository.GetByIdAsync(id) ?? throw new Exception("User not found");
    return user.ToResponse();
  }

  public async Task RemoveAsync(Guid id)
  {
    UserAggregate user = await _userRepository.GetByIdAsync(id) ?? throw new Exception("User not found");
    await _userRepository.RemoveAsync(user);
    await _unitOfWork.SaveChangesAsync();
  }

}
