using Core.Reservations;
using Shared;

namespace Core.Spaces.Delete;

internal sealed class DeleteSpaceService(
    ISpaceRepository spaceRepository,
    IReservationRepository reservationRepository
) : IDeleteSpaceService
{
    public async Task<Result> Handle(Guid spaceId, CancellationToken cancellationToken = default)
    {
        var space = await spaceRepository.GetById(spaceId, cancellationToken);

        if (space is null)
        {
            return Result.Failure(SpaceErrors.NotFound);
        }

        await spaceRepository.Delete(space, cancellationToken);

        return Result.Success();
    }
}