using Shared;

namespace Core.Users.Login;

public interface ILoginService
{
    public Task<Result<string>> Handle(string email, string password, CancellationToken cancellationToken = default);
}