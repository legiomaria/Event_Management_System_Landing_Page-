using EventMatcha.Domain.FAQs;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.FAQs.GetById
{
    public class GetFaqsByIdQueryHandler :
        IRequestHandler<GetFaqsByIdQuery, Result>
    {
        private readonly IFaqsRepository _faqsRepository;
        private readonly ILogger<GetFaqsByIdQueryHandler> _logger;

        public GetFaqsByIdQueryHandler(
            IFaqsRepository faqsRepository,
            ILogger<GetFaqsByIdQueryHandler> logger)
        {
            _faqsRepository = faqsRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetFaqsByIdQuery request, CancellationToken cancellationToken)
        {
            var existingFaqs = await _faqsRepository
                                .GetByIdAsync(request.Id, cancellationToken);

            if (existingFaqs == null)
            {
                return Result.Failure(FaqsErrors.FaqNotFound);
            }

            _logger.LogInformation("Details of faqs {@Id} retrieved", request.Id);
            var faqs = existingFaqs.ToDto();

            return Result<FaqsDto>.Success(faqs);
        }
    }
}
