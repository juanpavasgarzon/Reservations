using API.Extensions;
using API.Infrastructure;
using Core.Reservations;
using Core.Reservations.Get;
using Core.Spaces.Get;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Spaces.Get;

public class GetSpaceRequest : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("spaces", Handle)
            .WithTags(Tags.Spaces)
            .WithSummary("Get all spaces")
            .WithDescription("Fetches a list of spaces with optional filters.")
            .Produces<IEnumerable<Reservation>>()
            .Produces<BadRequestResult>(400)
            .Produces<UnauthorizedResult>(401)
            .RequireAuthorization();
    }

    private static async Task<IResult> Handle(IGetSpacesService service, CancellationToken cancellationToken)
    {
        var result = await service.Handle(cancellationToken);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}