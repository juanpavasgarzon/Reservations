using API.Extensions;
using API.Infrastructure;
using Core.Spaces.Create;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Spaces.Create;

internal sealed class CreateSpaceRequest : IEndpoint
{
    public sealed record Request(string Name, string? Description = default);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("spaces", Handle)
            .WithTags(Tags.Spaces)
            .WithSummary("Create a new space")
            .WithDescription("Creates a space for a specific space and time period.")
            .Produces<Guid>()
            .Produces<BadRequestResult>(400)
            .Produces<ConflictResult>(409)
            .RequireAuthorization();
    }

    private static async Task<IResult> Handle(
        Request request,
        IValidator<Request> validator,
        ICreateSpaceService service,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await service.Handle(request.Name, request.Description, cancellationToken);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}