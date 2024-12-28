using API.Extensions;
using API.Infrastructure;
using Core.Spaces.Delete;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Spaces.Delete;

internal sealed class DeleteSpaceRequest : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("spaces/{id:guid}", Handle)
            .WithTags(Tags.Spaces)
            .WithSummary("Delete a spaces")
            .WithDescription("Deletes an existing spaces by its unique identifier (id).")
            .Produces<NoContentResult>(204)
            .Produces<NotFoundResult>(404)
            .Produces<UnauthorizedResult>(401)
            .RequireAuthorization();
    }

    private static async Task<IResult> Handle(IDeleteSpaceService service, Guid id, CancellationToken cancellationToken)
    {
        var result = await service.Handle(id, cancellationToken);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}