using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories;

public class UserRepository(IdentityContext context) : IUserRepository
{
    public async Task AddUserAsync(User user)
    {
       await context.Users.AddAsync(user);
       await context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email) =>
        await context.Users
            .FirstOrDefaultAsync(u => u.Email == email) ?? null!;
    

    public async Task<User> GetUserByIdAsync(Guid id) =>
        await context.Users
             .FirstOrDefaultAsync(u => u.UserId == id) ?? null!;
    
    
    public async Task<bool> IsEmailTakenAsync(string email) =>
        await context.Users.AnyAsync(x => x.Email == email);
    

    public async Task UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}
