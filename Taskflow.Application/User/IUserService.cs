using Taskflow.Application.User.DTO;

namespace Taskflow.Application.User;

public interface IUserService
{

  public Task<UserResponse> CreateUserAsync(RegisterRequest payload);
  public Task<UserResponse> LoginAsync(LoginRequest payload);
  public Task<UserResponse> GetByEmailAsync(string email);
  public Task<UserResponse> GetByIdAsync(Guid id);
  public Task<List<UserResponse>> GetAllAsync();
  public Task RemoveAsync(Guid id);
}
