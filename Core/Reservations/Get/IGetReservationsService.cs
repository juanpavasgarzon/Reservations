using Shared;

namespace Core.Reservations.Get;

public interface IGetReservationsService
{
    public Task<Result<IEnumerable<Reservation>>> Handle(string? spaceId = null, Guid? userId = null,
        DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
}