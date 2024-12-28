using Shared;

namespace Core.Users;

public static class UserErrors
{
    public static readonly Error NotFoundByEmail = Error.NotFound(
        "Users.NotFoundByEmail",
        "The user with the specified email was not found");
    
    public static readonly Error WrongPassword = Error.NotFound(
        "Users.IncorrectPassword",
        "The password of specified user is wrong");

    public static readonly Error EmailNotUnique = Error.Conflict(
        "Users.EmailNotUnique",
        "The provided email is not unique");
}