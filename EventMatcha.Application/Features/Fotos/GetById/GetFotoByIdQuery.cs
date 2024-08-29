using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Fotos.GetById
{
    public class GetFotoByIdQuery
        :  IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
