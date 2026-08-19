using Taskflow.Application.User.DTO;
using Taskflow.Domain.User;

namespace Taskflow.Application.User.Mapper;

public static class UserMapper
{
  public static UserResponse ToResponse(this UserAggregate user, string? token = null)
  {
    return new UserResponse(
      user.Id,
      user.Username.Value,
      user.Email.Value,
      user.Role,
      token
    );
  }

}
