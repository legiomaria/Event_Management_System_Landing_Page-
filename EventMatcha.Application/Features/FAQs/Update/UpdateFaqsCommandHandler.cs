using EventMatcha.Domain.FAQs;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.FAQs.Update
{
    public class UpdateFaqsCommandHandler :
        IRequestHandler<UpdateFaqsCommand, Result>
    {
        private readonly IFaqsRepository _faqsRepository;
        private readonly ILogger<UpdateFaqsCommandHandler> _logger;

        public UpdateFaqsCommandHandler(
            IFaqsRepository faqsRepository,
            ILogger<UpdateFaqsCommandHandler> logger)
        {
            _faqsRepository = faqsRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(UpdateFaqsCommand request, CancellationToken cancellationToken)
        {
            var existingFaqs = await _faqsRepository
            .GetByIdAsync(request.Id, cancellationToken);

            if (existingFaqs == null)
            {
                return Result.Failure(FaqsErrors.FaqNotFound);
            }

            var faqsToUpdate = request.ToEntity();
            var updatedFaqs = await _faqsRepository
                .UpdateAsync(faqsToUpdate, cancellationToken);

            _logger.LogInformation("Faqs { @id } updated successfully", updatedFaqs.Id);

            return await Task.FromResult(Result<FaqsDto>.Success(updatedFaqs.ToDto()));
        }
    }
}
