using Core.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Reservations;

public class ReservationRepository(PostgresDbContext context) : IReservationRepository
{
    public async Task<bool> IsOverlaps(Reservation reservation, CancellationToken cancellationToken = default)
    {
        var overlapping = await context.Reservations
            .Where(r => r.UserId == reservation.UserId)
            .Where(r => r.SpaceId == reservation.SpaceId)
            .Where(r => reservation.StartDate < r.EndDate && reservation.EndDate > r.StartDate)
            .AnyAsync(cancellationToken);

        return overlapping;
    }

    public async Task<Guid> Create(Reservation reservation, CancellationToken cancellationToken = default)
    {
        context.Reservations.Add(reservation);

        await context.SaveChangesAsync(cancellationToken);

        return reservation.Id;
    }

    public async Task<Reservation?> GetByIdAsync(Guid reservationId, CancellationToken cancellationToken = default)
    {
        return await context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId, cancellationToken);
    }

    public async Task Delete(Reservation reservation, CancellationToken cancellationToken = default)
    {
        context.Reservations.Remove(reservation);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetReservationsAsync(
        string? spaceId,
        Guid? userId,
        DateTime? startDate,
        DateTime? endDate,
        CancellationToken cancellationToken = default)
    {
        var query = context.Reservations.AsQueryable();

        if (!string.IsNullOrEmpty(spaceId))
        {
            query = query.Where(r => r.SpaceId == spaceId);
        }

        if (userId.HasValue)
        {
            query = query.Where(r => r.UserId == userId.Value);
        }

        if (startDate.HasValue)
        {
            query = query.Where(r => r.StartDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(r => r.EndDate <= endDate.Value);
        }

        return await query.ToListAsync(cancellationToken);
    }
}