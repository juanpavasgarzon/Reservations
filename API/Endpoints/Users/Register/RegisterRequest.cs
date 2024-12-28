using API.Extensions;
using API.Infrastructure;
using Core.Users.Register;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Users.Register;

internal sealed class RegisterRequest : IEndpoint
{
    public sealed record Request(string Email, string FirstName, string LastName, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", Handle)
            .WithTags(Tags.Users)
            .WithSummary("User registration")
            .WithDescription("Registers a new user in the system.")
            .Produces<Guid>()
            .Produces<BadRequestResult>(400)
            .Produces<ConflictResult>(409);
    }

    private static async Task<IResult> Handle(
        Request request,
        IRegisterUserService userService,
        IValidator<Request> validator,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await userService.Handle(
            request.Email,
            request.FirstName,
            request.LastName,
            request.Password,
            cancellationToken);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}