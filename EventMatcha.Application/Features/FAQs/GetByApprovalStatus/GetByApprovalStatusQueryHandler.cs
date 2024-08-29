using EventMatcha.Domain.Primitives;
using EventMatcha.Domain.FAQs;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;


namespace EventMatcha.Application.Features.FAQs.GetByApprovalStatus
{
    public class GetByApprovalStatusQueryHandler 
        : IRequestHandler<GetByApprovalStatusQuery, Result>
    {
        private readonly IFaqsRepository _faqsRepository;
        private readonly ILogger<GetByApprovalStatusQueryHandler> _logger;
        public GetByApprovalStatusQueryHandler(IFaqsRepository faqsRepository,
            ILogger<GetByApprovalStatusQueryHandler> logger)
        {
            _faqsRepository = faqsRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetByApprovalStatusQuery request,  CancellationToken cancellationToken)
        {
            var Testimonials = await _faqsRepository
            .GetByApprovalStatusAsync(request.ApprovalStatus, (ResultFilter)request, cancellationToken);

            var existingFaqs = Testimonials.ToDto();

            _logger.LogInformation("Retrieved {@count} Testimonials", existingFaqs.Count.ToString());
            return Result<List<FaqsDto>>.Success(existingFaqs);
        }

    }
}
