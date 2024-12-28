using FluentValidation;

namespace API.Endpoints.Reservations.Create;

internal sealed class CreateReservationRequestValidator : AbstractValidator<CreateReservationRequest.Request>
{
    public CreateReservationRequestValidator()
    {
        RuleFor(r => r.SpaceId)
            .NotEmpty()
            .WithMessage("SpaceId is required.");

        RuleFor(r => r.StartDate)
            .NotEmpty()
            .WithMessage("StartDate is required.")
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("StartDate must be in the future.");

        RuleFor(r => r.EndDate)
            .NotEmpty()
            .WithMessage("EndDate is required.")
            .GreaterThan(r => r.StartDate)
            .WithMessage("EndDate must be after StartDate.");
    }
}