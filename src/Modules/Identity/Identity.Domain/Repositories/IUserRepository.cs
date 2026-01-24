using Identity.Domain.Entities;

namespace Identity.Domain.Repositories;

public interface IUserRepository
{
    public Task AddUserAsync(Users user);
    public Task UpdateUserAsync(Users user);
    public Task<Users> GetUserByEmailAsync(string email);
    public Task<Users> GetUserByIdAsync(Guid id);
    public Task<List<Users>> GetUsersByCompanyId(Guid companyId);
    public Task<bool> IsEmailTakenAsync(string email);
}
