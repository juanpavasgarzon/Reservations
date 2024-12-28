using API.Extensions;
using API.Infrastructure;
using Core.Users.Login;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Users.Login;

internal sealed class LoginRequest : IEndpoint
{
    public sealed record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", Handle)
            .WithTags(Tags.Users)
            .WithSummary("User login")
            .WithDescription("Authenticates a user and generates a JWT token for subsequent requests.")
            .Produces<string>()
            .Produces<BadRequestResult>(400);
    }

    private static async Task<IResult> Handle(
        Request request,
        IValidator<Request> validator,
        ILoginService service,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await service.Handle(request.Email, request.Password, cancellationToken);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}