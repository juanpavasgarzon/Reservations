using Shared;

namespace Core.Spaces.Create;

public interface ICreateSpaceService
{
    public Task<Result<Guid>> Handle(string name, string? description, CancellationToken cancellationToken = default);
}