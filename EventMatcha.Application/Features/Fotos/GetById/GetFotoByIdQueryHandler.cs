using EventMatcha.Domain.Fotos;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Fotos.GetById
{
    public class GetFotoByIdQueryHandler :
        IRequestHandler<GetFotoByIdQuery, Result>
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly ILogger<GetFotoByIdQueryHandler> _logger;

        public GetFotoByIdQueryHandler(
            IFotoRepository fotoRepository,
            ILogger<GetFotoByIdQueryHandler> logger)
        {
            _fotoRepository = fotoRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetFotoByIdQuery request, CancellationToken cancellationToken)
        {
            var existingFoto = await _fotoRepository
                                .GetByIdAsync(request.Id, cancellationToken);

            if (existingFoto == null)
            {
                return Result.Failure(FotoErrors.FotoNotFound);
            }

            _logger.LogInformation("Details of foto { @Id } retrieved", request.Id);
            var foto = existingFoto.ToDto();

            return Result<FotoDto>.Success(foto);
        }
    }
}
