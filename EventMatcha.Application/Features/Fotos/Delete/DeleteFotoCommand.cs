using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Fotos.Delete
{
    public class DeleteFotoCommand :
        IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
