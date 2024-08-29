using FluentValidation;


namespace EventMatcha.Application.Features.Testimonials.Create
{
    public class CreateTestimonialCommandValidator 
        : AbstractValidator<CreateTestimonialCommand>
    {
        public CreateTestimonialCommandValidator()
        {
            RuleFor(p => p.AuthorName)
                .NotEmpty()
                .WithMessage("Author name is required");

            RuleFor(p => p.Text)
                .NotEmpty()
                .WithMessage("Text is required");

            RuleFor(p => p.ApprovalStatus)
                .NotEmpty()
                .WithMessage("Approval status is required");

            RuleFor(p => p.AvatarUrl)
                .NotEmpty()
                .WithMessage("Avatar url is required");

            RuleFor(p => p.UserType)
                .NotEmpty()
                .WithMessage("User type is required");
        }
    }
}
