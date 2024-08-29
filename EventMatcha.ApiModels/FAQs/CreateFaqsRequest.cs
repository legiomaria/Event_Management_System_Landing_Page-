using EventMatcha.Infrastructure.Enum;

namespace EventMatcha.ApiModels.FAQs;

public class CreateFaqsRequest
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public FaqsCategoryEnum Category { get; set; }
    public ApprovalStatusEnum ApprovalStatus { get; set; }
}
