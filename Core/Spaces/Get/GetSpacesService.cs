using Shared;

namespace Core.Spaces.Get;

internal sealed class GetSpacesService(ISpaceRepository spaceRepository) : IGetSpacesService
{
    public async Task<Result<IEnumerable<Space>>> Handle(CancellationToken cancellationToken = default)
    {
        var reservations = await spaceRepository.Get(cancellationToken);

        return Result.Success(reservations);
    }
}