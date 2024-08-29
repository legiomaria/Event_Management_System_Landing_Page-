using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using EventMatcha.Domain.Fotos;

namespace EventMatcha.Application.Features.Fotos.Create
{
    public class CreateFotoCommandHandler
        : IRequestHandler<CreateFotoCommand, Result>
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly ILogger<CreateFotoCommandHandler> _logger;

        public CreateFotoCommandHandler(
            IFotoRepository fotoRepository,
            ILogger<CreateFotoCommandHandler> logger
            )
        {
            _logger = logger;
            _fotoRepository = fotoRepository;
        }

        public async Task<Result> Handle(CreateFotoCommand request, CancellationToken cancellationToken)
        {
            var foto = request.ToEntity();

            var fotoExist = await _fotoRepository.ExistAsync(foto, cancellationToken);

            if (fotoExist)
            {
                return Result.Failure(FotoErrors.FotoExist);
            }

            var fotoCreated = await _fotoRepository.CreateAsync(foto, cancellationToken);

            _logger.LogInformation("Foto { @Id } created", fotoCreated.Id);

            return Result<FotoDto>.Success(fotoCreated.ToDto());
        }
    }
}
