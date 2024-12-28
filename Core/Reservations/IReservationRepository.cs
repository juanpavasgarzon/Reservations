namespace Core.Reservations;

public interface IReservationRepository
{
    public Task<bool> IsOverlaps(Reservation reservation, CancellationToken cancellationToken = default);

    public Task<Guid> Create(Reservation reservation, CancellationToken cancellationToken = default);

    public Task<Reservation?> GetById(Guid reservationId, CancellationToken cancellationToken = default);

    public Task Delete(Reservation reservation, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Reservation>> Get(
        Guid? spaceId,
        Guid? userId,
        DateTime? startDate,
        DateTime? endDate,
        CancellationToken cancellationToken = default);
}