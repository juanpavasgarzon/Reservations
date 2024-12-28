using Shared;

namespace Core.Reservations;

public static class ReservationErrors
{
    public static readonly Error Overlapped = Error.Conflict(
        "Reservations.Overlapped",
        "You cannot reserve two spaces at the same time.");

    public static readonly Error NotFound = Error.NotFound(
        "Reservations.NotFoundById",
        "The user with the specified id was not found");

    public static readonly Error NotAuthorized = Error.Failure(
        "Reservations.Unauthorized",
        "You are not authorized to perform this action.");
}