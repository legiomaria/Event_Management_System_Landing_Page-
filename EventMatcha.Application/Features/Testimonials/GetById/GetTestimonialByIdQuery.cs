using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Testimonials.GetById
{
    public class GetTestimonialByIdQuery 
        : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
