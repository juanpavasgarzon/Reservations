using Core.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Users;

public class UserRepository(PostgresDbContext context) : IUserRepository
{
    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken = default)
    {
        return await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<Guid> Create(User user, CancellationToken cancellationToken = default)
    {
        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}