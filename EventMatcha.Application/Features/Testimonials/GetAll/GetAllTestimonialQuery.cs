using EventMatcha.Domain.Primitives;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Testimonials.GetAll
{
    public class GetAllTestimonialQuery : ResultFilter, IRequest<Result>
    {
    }
}
