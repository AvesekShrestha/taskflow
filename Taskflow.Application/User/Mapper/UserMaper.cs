using Taskflow.Application.User.DTO;
using Taskflow.Domain.User;

namespace Taskflow.Application.User.Mapper;

public static class UserMapper
{
  public static UserResponse ToResponse(this UserAggregate user)
  {
    return new UserResponse(
      user.Id,
      user.Username.Value,
      user.Email.Value,
      user.Role
    );
  }

  public static UserAggregate ToAggregate(this RegisterRequest request, Guid id)
  {
    return UserAggregate.Create(
        id,
      request.Username,
      request.Email,
      request.Password
    );
  }
}
