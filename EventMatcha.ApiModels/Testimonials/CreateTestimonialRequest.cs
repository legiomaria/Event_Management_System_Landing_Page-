using EventMatcha.Infrastructure.Enum;

namespace EventMatcha.ApiModels.Testimonials
{
    public class CreateTestimonialRequest
    {
        public string AuthorName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public ApprovalStatusEnum ApprovalStatus { get; set; } 
        public string AvatarUrl { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
    }
}
