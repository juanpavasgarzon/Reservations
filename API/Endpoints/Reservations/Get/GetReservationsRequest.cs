using API.Extensions;
using API.Infrastructure;
using Core.Reservations;
using Core.Reservations.Get;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Reservations.Get;

public class GetReservationsRequest : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("reservations", Handle)
            .WithTags(Tags.Reservations)
            .WithSummary("Get all reservations")
            .WithDescription("Fetches a list of reservations with optional filters.")
            .Produces<IEnumerable<Reservation>>()
            .Produces<BadRequestResult>(400)
            .Produces<UnauthorizedResult>(401)
            .RequireAuthorization();
    }

    private static async Task<IResult> Handle(
        [FromQuery] Guid? spaceId,
        [FromQuery] Guid? userId,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        [FromServices] IGetReservationsService service,
        CancellationToken cancellationToken)
    {
        var result = await service.Handle(spaceId, userId, startDate, endDate, cancellationToken);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}