using Shared;

namespace Core.Spaces.Delete;

internal sealed class DeleteSpaceService(ISpaceRepository spaceRepository) : IDeleteSpaceService
{
    public async Task<Result> Handle(Guid spaceId, CancellationToken cancellationToken = default)
    {
        var reservation = await spaceRepository.GetById(spaceId, cancellationToken);

        if (reservation is null)
        {
            return Result.Failure(SpaceErrors.NotFound);
        }

        await spaceRepository.Delete(reservation, cancellationToken);

        return Result.Success();
    }
}