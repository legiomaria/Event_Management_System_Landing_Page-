using EventMatcha.Domain.FAQs;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.FAQs.Delete
{
    public class DeleteFaqsCommandHandler :
        IRequestHandler<DeleteFaqsCommand, Result>
    {
        private readonly IFaqsRepository _faqsRepository;
        private readonly ILogger<DeleteFaqsCommandHandler> _logger;

        public DeleteFaqsCommandHandler(
            IFaqsRepository faqsRepository,
            ILogger<DeleteFaqsCommandHandler> logger
            )
        {
            _faqsRepository = faqsRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteFaqsCommand request, CancellationToken cancellationToken)
        {
            var existingFaqs = await _faqsRepository
                                .GetByIdAsync(request.Id, cancellationToken);

            if (existingFaqs == null)
            {
                return Result.Failure(FaqsErrors.FaqNotFound);
            }

            var rsp = await _faqsRepository
                .DeleteAsync(request.Id, cancellationToken);

            return Result<bool>.Success(rsp);
        }
    }
}
