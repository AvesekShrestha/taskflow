namespace Taskflow.Domain.User;

public interface IUserRepository
{
  Task<UserAggregate?> GetByIdAsync(Guid id);
  Task<UserAggregate?> GetByEmailAsync(string email);
  Task AddAsync(UserAggregate user);
  Task RemoveAsync(UserAggregate user);

}
