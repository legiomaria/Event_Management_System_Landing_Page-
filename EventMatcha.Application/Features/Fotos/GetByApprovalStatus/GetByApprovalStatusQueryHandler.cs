using EventMatcha.Domain.Primitives;
using EventMatcha.Domain.Fotos;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;


namespace EventMatcha.Application.Features.Fotos.GetByApprovalStatus
{
    public class GetByApprovalStatusQueryHandler 
        : IRequestHandler<GetByApprovalStatusQuery, Result>
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly ILogger<GetByApprovalStatusQueryHandler> _logger;
        public GetByApprovalStatusQueryHandler(IFotoRepository fotoRepository,
            ILogger<GetByApprovalStatusQueryHandler> logger)
        {
            _fotoRepository = fotoRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetByApprovalStatusQuery request,  CancellationToken cancellationToken)
        {
            var Fotos = await _fotoRepository
            .GetByApprovalStatusAsync(request.ApprovalStatus, (ResultFilter)request, cancellationToken);

            var existingFotos = Fotos.ToDto();

            _logger.LogInformation("Retrieved {@count} Fotos", existingFotos.Count.ToString());
            return Result<List<FotoDto>>.Success(existingFotos);
        }

    }
}
