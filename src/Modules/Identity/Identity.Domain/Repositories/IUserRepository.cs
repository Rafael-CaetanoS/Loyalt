using Identity.Domain.Entities;

namespace Identity.Domain.Repositories;

public interface IUserRepository
{
    public Task AddUserAsync(User user);
    public Task UpdateUserAsync(User user);
    public Task<User> GetUserByEmailAsync(string email);
    public Task<User> GetUserByIdAsync(Guid id);
    public Task<bool> IsEmailTakenAsync(string email);
}
