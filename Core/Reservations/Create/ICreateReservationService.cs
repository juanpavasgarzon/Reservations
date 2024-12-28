using Shared;

namespace Core.Reservations.Create;

public interface ICreateReservationService
{
    public Task<Result<Guid>> Handle(
        Guid spaceId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);
}