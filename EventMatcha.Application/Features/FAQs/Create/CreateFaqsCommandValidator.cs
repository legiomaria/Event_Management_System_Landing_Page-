using FluentValidation;

namespace EventMatcha.Application.Features.FAQs.Create;

public class CreateFaqsCommandValidator
    : AbstractValidator<CreateFaqsCommand>
{
    public CreateFaqsCommandValidator()
    {
        RuleFor(m => m.Question)
            .NotEmpty()
            .WithMessage("Question is required.");

        RuleFor(m => m.Answer)
            .NotEmpty()
            .WithMessage("Faqs Answer is required");

        RuleFor(m => m.Category)
            .NotEmpty()
            .WithMessage("Faqs Category   is required");

        RuleFor(p => p.ApprovalStatus)
                .NotEmpty()
                .WithMessage("Approval status is required");


    }
}
