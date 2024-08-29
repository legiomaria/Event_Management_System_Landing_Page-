using EventMatcha.Domain.Fotos;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Fotos.Delete
{
    public class DeleteFotoCommandHandler :
        IRequestHandler<DeleteFotoCommand, Result>
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly ILogger<DeleteFotoCommandHandler> _logger;

        public DeleteFotoCommandHandler(
            IFotoRepository fotoRepository,
            ILogger<DeleteFotoCommandHandler> logger
            )
        {
            _fotoRepository = fotoRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteFotoCommand request, CancellationToken cancellationToken)
        {
            var existingFoto = await _fotoRepository
                                .GetByIdAsync(request.Id, cancellationToken);

            if (existingFoto == null)
            {
                return Result.Failure(FotoErrors.FotoNotFound);
            }

            var rsp = await _fotoRepository
                .DeleteAsync(request.Id, cancellationToken);

            return Result<bool>.Success(rsp);
        }
    }
}
