using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using EventMatcha.Domain.FAQs;

namespace EventMatcha.Application.Features.FAQs.GetAll
{
    public class GetAllFaqsQueryHandler :
        IRequestHandler<GetAllFaqsQuery, Result>
    {
        private IFaqsRepository _faqsRepository;
        private ILogger<GetAllFaqsQueryHandler> _logger;

        public GetAllFaqsQueryHandler(
            IFaqsRepository faqsRepository,
            ILogger<GetAllFaqsQueryHandler> logger)
        {
            _faqsRepository = faqsRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetAllFaqsQuery request, CancellationToken cancellationToken)
        {
            var faqss = await _faqsRepository
                        .GetAllAsync(request, cancellationToken);

            var existingFaqs = faqss.ToDto();

            _logger.LogInformation("Retrieved { @count } faqss", existingFaqs.Count.ToString());

            return Result<List<FaqsDto>>.Success(existingFaqs);
        }


    }
}
