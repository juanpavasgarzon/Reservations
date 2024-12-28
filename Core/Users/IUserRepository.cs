namespace Core.Users;

public interface IUserRepository
{
    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken = default);
    
    public Task<Guid> Create(User user, CancellationToken cancellationToken = default);
}