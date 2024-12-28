using FluentValidation;

namespace API.Endpoints.Spaces.Create;

internal sealed class CreateSpaceRequestValidator : AbstractValidator<CreateSpaceRequest.Request>
{
    public CreateSpaceRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Space name is required.");
    }
}