using EventMatcha.Infrastructure.Enum;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.FAQs.Update
{
    public class UpdateFaqsCommand :
        IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ApprovalStatusEnum ApprovalStatus { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }

    }
}
