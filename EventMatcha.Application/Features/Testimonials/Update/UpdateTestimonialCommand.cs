using EventMatcha.Infrastructure.Enum;
using EventMatcha.Shared;
using MediatR;


namespace EventMatcha.Application.Features.Testimonials.Update
{
    public class UpdateTestimonialCommand 
        : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string AvatarUrl {  get; set; } = string.Empty;
        public ApprovalStatusEnum ApprovalStatus { get; set; }
        public string UserType { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
    }
}
