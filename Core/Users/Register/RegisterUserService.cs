using Core.Authentication;
using Shared;

namespace Core.Users.Register;

internal sealed class RegisterUserService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher
) : IRegisterUserService
{
    public async Task<Result<Guid>> Handle(
        string email,
        string firstName,
        string lastName,
        string password,
        CancellationToken cancellationToken = default)
    {
        if (await userRepository.GetByEmail(email, cancellationToken) is not null)
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PasswordHash = passwordHasher.Hash(password)
        };

        var id = await userRepository.Create(user, cancellationToken);

        return id;
    }
}