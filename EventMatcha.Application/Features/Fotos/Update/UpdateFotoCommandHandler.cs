using EventMatcha.Domain.Fotos;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Fotos.Update
{
    public class UpdateFotoCommandHandler :
        IRequestHandler<UpdateFotoCommand, Result>
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly ILogger<UpdateFotoCommandHandler> _logger;

        public UpdateFotoCommandHandler(
            IFotoRepository fotoRepository,
            ILogger<UpdateFotoCommandHandler> logger)
        {
            _fotoRepository = fotoRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(UpdateFotoCommand request, CancellationToken cancellationToken)
        {
            var existingFoto = await _fotoRepository
            .GetByIdAsync(request.Id, cancellationToken);

            if (existingFoto == null)
            {
                return Result.Failure(FotoErrors.FotoNotFound);
            }

            var fotoToUpdate = request.ToEntity();
            var updatedFoto = await _fotoRepository
                .UpdateAsync(fotoToUpdate, cancellationToken);

            _logger.LogInformation("Foto {@id} updated successfully", updatedFoto.Id);

            return await Task.FromResult(Result<FotoDto>.Success(updatedFoto.ToDto()));
        }
    }
}
