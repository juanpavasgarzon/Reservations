using Core.Authentication;
using Shared;

namespace Core.Reservations.Delete;

internal sealed class DeleteReservationService(
    IReservationRepository reservationRepository,
    IUserContext userContext
) : IDeleteReservationService
{
    public async Task<Result> Handle(Guid reservationId, CancellationToken cancellationToken = default)
    {
        var reservation = await reservationRepository.GetByIdAsync(reservationId, cancellationToken);

        if (reservation is null)
        {
            return Result.Failure(ReservationErrors.NotFound);
        }

        if (reservation.UserId != userContext.UserId)
        {
            return Result.Failure(ReservationErrors.NotAuthorized);
        }

        await reservationRepository.Delete(reservation, cancellationToken);

        return Result.Success();
    }
}