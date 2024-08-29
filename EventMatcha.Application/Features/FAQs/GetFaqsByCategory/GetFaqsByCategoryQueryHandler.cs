using EventMatcha.Domain.FAQs;
using EventMatcha.Domain.Primitives;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.FAQs.GetFaqsByCategory
{
    public class GetFaqsByGroupIdQueryHandler :
        IRequestHandler<GetFaqsByCategoryQuery, Result>
    {
        private readonly IFaqsRepository _faqsRepository;
        private readonly ILogger<GetFaqsByGroupIdQueryHandler> _logger;

        public GetFaqsByGroupIdQueryHandler(
            IFaqsRepository faqsRepository,
            ILogger<GetFaqsByGroupIdQueryHandler> logger)
        {
            _faqsRepository = faqsRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetFaqsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var faqs = await _faqsRepository
            .GetByFaqsCategoryAsync(request.Category, (ResultFilter)request, cancellationToken);

            var existingFaqs = faqs.ToDto();

            _logger.LogInformation("Retrieved {@count} faqs", existingFaqs.Count.ToString());

            return Result<List<FaqsDto>>.Success(existingFaqs);
        }
    }
}
