using FluentValidation;

namespace EventMatcha.Application.Features.Testimonials.Update
{
    public class UpdateTestimonialCommandValidation 
        : AbstractValidator<UpdateTestimonialCommand>
    {
        public UpdateTestimonialCommandValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id is required");

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
                .WithMessage("Avatar Url is required");

            RuleFor(p => p.UserType)
                .NotEmpty()
                .WithMessage("User type is required");
        }
    }
}
