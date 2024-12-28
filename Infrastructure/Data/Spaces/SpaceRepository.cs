using Core.Spaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Spaces;

public class SpaceRepository(PostgresDbContext context) : ISpaceRepository
{
    public async Task<Space?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Spaces.FindAsync([id], cancellationToken);
    }

    public async Task<Space?> GetByName(string name, CancellationToken cancellationToken = default)
    {
        return await context.Spaces.AsNoTracking()
            .SingleOrDefaultAsync(s => s.Name == name, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<Space>> Get(CancellationToken cancellationToken = default)
    {
        return await context.Spaces.ToListAsync(cancellationToken);
    }

    public async Task<Guid> Create(Space space, CancellationToken cancellationToken = default)
    {
        context.Spaces.Add(space);

        await context.SaveChangesAsync(cancellationToken);

        return space.Id;
    }

    public async Task Delete(Space space, CancellationToken cancellationToken = default)
    {
        context.Spaces.Remove(space);

        await context.SaveChangesAsync(cancellationToken);
    }
}