using EventMatcha.ApiModels.Common;

namespace EventMatcha.ApiModels.FAQs
{
    public class GetFaqsByCategoryRequest : FilterRequest
    {
        public string Category { get; set; } = string.Empty;
    }
}
