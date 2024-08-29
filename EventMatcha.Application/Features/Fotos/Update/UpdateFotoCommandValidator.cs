using FluentValidation;

namespace EventMatcha.Application.Features.Fotos.Update
{
    public class UpdateFotoCommandValidator :
        AbstractValidator<UpdateFotoCommand>
    {
        public UpdateFotoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");

            RuleFor(m => m.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Foto Description is required");

            RuleFor(m => m.Path)
                .NotEmpty()
                .WithMessage("Foto Path is required");

            RuleFor(m => m.AvatarUrl)
                .NotEmpty()
                .WithMessage("Avatar Url  is required");

            RuleFor(p => p.ApprovalStatus)
              .NotEmpty()
              .WithMessage("Approval status is required");

            RuleFor(m => m.ImageOwner)
               .NotEmpty()
               .WithMessage("Image Owner Url  is required");

        }
    }
}
