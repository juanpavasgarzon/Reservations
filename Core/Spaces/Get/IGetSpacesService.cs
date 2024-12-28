using Shared;

namespace Core.Spaces.Get;

public interface IGetSpacesService
{
    public Task<Result<IEnumerable<Space>>> Handle(CancellationToken cancellationToken = default);
}