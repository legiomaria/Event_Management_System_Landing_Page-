using EventMatcha.Infrastructure.Enum;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Testimonials.Create
{
    public class CreateTestimonialCommand 
        : IRequest<Result>
    {
        public string AuthorName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public ApprovalStatusEnum ApprovalStatus { get; set; } 
        public string AvatarUrl { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty; 
        public DateTime CreatedOn { get; set; }
    }
}
