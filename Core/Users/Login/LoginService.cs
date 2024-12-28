using Core.Authentication;
using Shared;

namespace Core.Users.Login;

internal sealed class LoginService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenProvider tokenProvider) : ILoginService
{
    public async Task<Result<string>> Handle(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByEmail(email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        var verified = passwordHasher.Verify(password, user.PasswordHash);

        if (!verified)
        {
            return Result.Failure<string>(UserErrors.WrongPassword);
        }

        var token = tokenProvider.Create(user);

        return token;
    }
}