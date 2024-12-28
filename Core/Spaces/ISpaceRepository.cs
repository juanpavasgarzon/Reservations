namespace Core.Spaces;

public interface ISpaceRepository
{
    public Task<Space?> GetById(Guid id, CancellationToken cancellationToken = default);
    
    public Task<Space?> GetByName(string name, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Space>> Get(CancellationToken cancellationToken = default);

    public Task<Guid> Create(Space space, CancellationToken cancellationToken = default);

    public Task Delete(Space space, CancellationToken cancellationToken = default);
}