using Shared;

namespace Core.Reservations.Delete;

public interface IDeleteReservationService
{
    public Task<Result> Handle(Guid reservationId, CancellationToken cancellationToken = default);
}