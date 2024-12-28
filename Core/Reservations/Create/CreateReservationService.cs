using Core.Authentication;
using Shared;

namespace Core.Reservations.Create;

internal sealed class CreateReservationService(
    IReservationRepository reservationRepository,
    IUserContext userContext
) : ICreateReservationService
{
    public async Task<Result<Guid>> Handle(
        string spaceId, 
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            SpaceId = spaceId,
            UserId = userContext.UserId,
            StartDate = startDate,
            EndDate = endDate
        };

        if (await reservationRepository.IsOverlaps(reservation, cancellationToken))
        {
            return Result.Failure<Guid>(ReservationErrors.Overlapped);
        }

        var id = await reservationRepository.Create(reservation, cancellationToken);

        return id;
    }
}