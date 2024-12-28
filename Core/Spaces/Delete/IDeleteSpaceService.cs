using Shared;

namespace Core.Spaces.Delete;

public interface IDeleteSpaceService
{
    public Task<Result> Handle(Guid spaceId, CancellationToken cancellationToken = default);
}