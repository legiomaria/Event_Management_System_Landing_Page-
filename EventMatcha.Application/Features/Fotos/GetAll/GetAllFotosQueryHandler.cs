using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using EventMatcha.Domain.Fotos;

namespace EventMatcha.Application.Features.Fotos.GetAll
{
    public class GetAllFotosQueryHandler :
        IRequestHandler<GetAllFotosQuery, Result>
    {
        private IFotoRepository _fotoRepository;
        private ILogger<GetAllFotosQueryHandler> _logger;

        public GetAllFotosQueryHandler(
            IFotoRepository fotoRepository,
            ILogger<GetAllFotosQueryHandler> logger)
        {
            _fotoRepository = fotoRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetAllFotosQuery request, CancellationToken cancellationToken)
        {
            var fotos = await _fotoRepository
                        .GetAllAsync(request, cancellationToken);

            var existingFotos = fotos.ToDto();

            _logger.LogInformation("Retrieved { @count } fotos", existingFotos.Count.ToString());

            return Result<List<FotoDto>>.Success(existingFotos);
        }


    }
}
