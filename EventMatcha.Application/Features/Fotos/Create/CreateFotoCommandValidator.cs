using FluentValidation;

namespace EventMatcha.Application.Features.Fotos.Create;

public class CreateFotoCommandValidator
    : AbstractValidator<CreateFotoCommand>
{
    public CreateFotoCommandValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(m => m.Description)
            .NotEmpty()
            .WithMessage("Foto Description is required");

        RuleFor(m => m.Path)
            .NotEmpty()
            .WithMessage("Foto Path   is required");

        RuleFor(m => m.AvatarUrl)
            .NotEmpty()
            .WithMessage("Avatar Url  is required");

        RuleFor(m => m.ImageOwner)
           .NotEmpty()
           .WithMessage("Image Owner Url  is required");

        RuleFor(p => p.ApprovalStatus)
                .NotEmpty()
                .WithMessage("Approval status is required");
    }
}
