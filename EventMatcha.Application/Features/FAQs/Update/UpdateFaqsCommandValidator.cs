using FluentValidation;

namespace EventMatcha.Application.Features.FAQs.Update
{
    public class UpdateFaqsCommandValidator :
        AbstractValidator<UpdateFaqsCommand>
    {
        public UpdateFaqsCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");

            RuleFor(m => m.Question)
            .NotEmpty()
            .WithMessage("Question is required.");

            RuleFor(m => m.Answer)
                .NotEmpty()
                .WithMessage("Answer Description is required");

            RuleFor(m => m.Category)
                .NotEmpty()
                .WithMessage("Category Path   is required");

        }
    }
}
