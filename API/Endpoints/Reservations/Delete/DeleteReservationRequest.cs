using API.Extensions;
using API.Infrastructure;
using Core.Reservations.Delete;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Reservations.Delete;

internal sealed class DeleteReservationRequest : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("reservations/{id:guid}", Handle)
            .WithTags(Tags.Reservations)
            .WithSummary("Delete a reservation")
            .WithDescription("Deletes an existing reservation by its unique identifier (id).")
            .Produces<NoContentResult>(204)
            .Produces<NotFoundResult>(404)
            .Produces<UnauthorizedResult>(401)
            .RequireAuthorization();
    }

    private static async Task<IResult> Handle(IDeleteReservationService service, Guid id,
        CancellationToken cancellationToken)
    {
        var result = await service.Handle(id, cancellationToken);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}