using Taskflow.Application.User.Authentication;
using Taskflow.Application.User.DTO;
using Taskflow.Application.User.Mapper;
using Taskflow.Domain.Shared.Interfaces;
using Taskflow.Domain.User;

namespace Taskflow.Application.User;

public sealed class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ITokenService tokenService) : IUserService
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IPasswordHasher _passwordHasher = passwordHasher;
  private readonly ITokenService _tokenService = tokenService;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<UserResponse> CreateUserAsync(RegisterRequest payload)
  {
    UserAggregate? existingUser = await _userRepository.GetByEmailAsync(payload.Email);
    if (existingUser is not null) throw new InvalidOperationException("User already exists");

    string hashedPassword = _passwordHasher.HashPassword(payload.Password);
    Guid Id = Guid.NewGuid();

    UserAggregate user = UserAggregate.Create(
        Id,
        payload.Username,
        payload.Email,
      hashedPassword
        );

    await _userRepository.AddAsync(user);
    await _unitOfWork.SaveChangesAsync();

    return user.ToResponse();
  }

  public async Task<UserResponse> LoginAsync(LoginRequest payload)
  {

    UserAggregate user = await _userRepository.GetByEmailAsync(payload.Email) ?? throw new Exception("User not found");

    bool verified = _passwordHasher.VerifyPassword(payload.Password, user.Password.Value);
    if (!verified) throw new Exception("Invalid password");

    string token = _tokenService.GenerateToken(user);
    return user.ToResponse(token);
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

  public async Task<List<UserResponse>> GetAllAsync()
  {
    List<UserAggregate> users = await _userRepository.GetAllAsync();
    List<UserResponse> response = [.. users.Select(user => user.ToResponse())];
    return response;
  }

}
