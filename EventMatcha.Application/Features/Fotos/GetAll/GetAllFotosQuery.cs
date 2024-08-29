using EventMatcha.Domain.Primitives;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Fotos.GetAll
{
    public class GetAllFotosQuery : ResultFilter, IRequest<Result>
    {
    }
}

