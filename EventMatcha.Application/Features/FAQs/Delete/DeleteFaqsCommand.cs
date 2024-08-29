using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.FAQs.Delete
{
    public class DeleteFaqsCommand :
        IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
