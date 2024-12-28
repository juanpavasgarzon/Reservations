using Shared;

namespace Core.Spaces.Create;

internal sealed class CreateSpaceService(ISpaceRepository spaceRepository) : ICreateSpaceService
{
    public async Task<Result<Guid>> Handle(
        string name,
        string? description,
        CancellationToken cancellationToken = default)
    {
        if (await spaceRepository.GetByName(name, cancellationToken) is not null)
        {
            return Result.Failure<Guid>(SpaceErrors.SpaceNotUnique);
        }

        var space = new Space
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };

        var id = await spaceRepository.Create(space, cancellationToken);

        return id;
    }
}