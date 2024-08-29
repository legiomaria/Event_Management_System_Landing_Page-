using EventMatcha.ApiModels.Common;

namespace EventMatcha.ApiModels.Testimonials
{

    public class GetByApprovalStatusRequest : FilterRequest
    {
        public string ApprovalStatus { get; set; } = string.Empty;
    }

}
