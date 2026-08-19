using Taskflow.Domain.User;

namespace Taskflow.Application.User.Authentication;

public interface ITokenService
{
  string GenerateToken(UserAggregate user);
}
