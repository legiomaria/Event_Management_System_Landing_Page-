using EventMatcha.ApiModels.Common;
using EventMatcha.Infrastructure.Enum;

namespace EventMatcha.ApiModels.FAQs
{

    public class GetByApprovalStatusRequest : FilterRequest
    {
        public string ApprovalStatus { get; set; } = string.Empty;
    }

}
