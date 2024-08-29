using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using EventMatcha.Domain.FAQs;

namespace EventMatcha.Application.Features.FAQs.Create
{
    public class CreateFaqsCommandHandler
        : IRequestHandler<CreateFaqsCommand, Result>
    {
        private readonly IFaqsRepository _faqsRepository;
        private readonly ILogger<CreateFaqsCommandHandler> _logger;

        public CreateFaqsCommandHandler(
            IFaqsRepository faqsRepository,
            ILogger<CreateFaqsCommandHandler> logger
            )
        {
            _logger = logger;
            _faqsRepository = faqsRepository;
        }

        public async Task<Result> Handle(CreateFaqsCommand request, CancellationToken cancellationToken)
        {
            var faqs = request.ToEntity();

            var faqsExist = await _faqsRepository.ExistAsync(faqs, cancellationToken);

            if (faqsExist)
            {
                return Result.Failure(FaqsErrors.FaqExist);
            }

            var faqsCreated = await _faqsRepository.CreateAsync(faqs, cancellationToken);

            _logger.LogInformation("Faqs {Id} created", faqsCreated.Id);

            return Result<FaqsDto>.Success(faqsCreated.ToDto());
        }
    }
}
