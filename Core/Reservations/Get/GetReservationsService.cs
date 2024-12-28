using Shared;

namespace Core.Reservations.Get;

internal sealed class GetReservationsService(
    IReservationRepository reservationRepository
) : IGetReservationsService
{
    public async Task<Result<IEnumerable<Reservation>>> Handle(string? spaceId = null, Guid? userId = null,
        DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default)
    {
        var reservations = await reservationRepository.GetReservationsAsync(
            spaceId, userId, startDate, endDate, cancellationToken
        );

        return Result.Success(reservations);
    }
}