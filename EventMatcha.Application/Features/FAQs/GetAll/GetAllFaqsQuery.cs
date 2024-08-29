using EventMatcha.Domain.Primitives;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.FAQs.GetAll
{
    public class GetAllFaqsQuery : ResultFilter, IRequest<Result>
    {
    }
}

