using Shared;

namespace Core.Users.Register;

public interface IRegisterUserService
{
    public Task<Result<Guid>> Handle(
        string email,
        string firstName,
        string lastName,
        string password,
        CancellationToken cancellationToken = default);
}