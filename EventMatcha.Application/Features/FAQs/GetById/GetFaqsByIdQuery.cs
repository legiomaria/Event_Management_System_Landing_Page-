using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.FAQs.GetById
{
    public class GetFaqsByIdQuery :  IRequest<Result>
    {
        public Guid Id { get; set; }


    }


}
