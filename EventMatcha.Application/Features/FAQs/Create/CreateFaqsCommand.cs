using EventMatcha.Infrastructure.Enum;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.FAQs.Create
{
    public class CreateFaqsCommand
        : IRequest<Result>
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public FaqsCategoryEnum Category { get; set; }
        public ApprovalStatusEnum ApprovalStatus { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

    }
}
