using API.Extensions;
using API.Infrastructure;
using Core.Reservations.Create;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Reservations.Create;

internal sealed class CreateReservationRequest : IEndpoint
{
    public sealed record Request(string SpaceId, DateTime StartDate, DateTime EndDate);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("reservations", Handle)
            .WithTags(Tags.Reservations)
            .WithSummary("Create a new reservation")
            .WithDescription("Creates a reservation for a specific space and time period.")
            .Produces<Guid>()
            .Produces<BadRequestResult>(400)
            .Produces<ConflictResult>(409)
            .RequireAuthorization();
    }

    private static async Task<IResult> Handle(
        Request request,
        IValidator<Request> validator,
        ICreateReservationService service,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await service.Handle(request.SpaceId, request.StartDate, request.EndDate, cancellationToken);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}