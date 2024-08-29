using EventMatcha.Shared;
using MediatR;


namespace EventMatcha.Application.Features.Testimonials.Delete
{
    public class DeleteTestimonialCommand 
        : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
