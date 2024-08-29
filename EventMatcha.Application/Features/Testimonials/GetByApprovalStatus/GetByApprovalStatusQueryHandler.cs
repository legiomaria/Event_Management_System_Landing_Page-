using EventMatcha.Domain.Primitives;
using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;


namespace EventMatcha.Application.Features.Testimonials.GetByApprovalStatus
{
    public class GetByApprovalStatusQueryHandler 
        : IRequestHandler<GetByApprovalStatusQuery, Result>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<GetByApprovalStatusQueryHandler> _logger;
        public GetByApprovalStatusQueryHandler(ITestimonialRepository testimonialRepository,
            ILogger<GetByApprovalStatusQueryHandler> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;
        }

        public async Task<Result> Handle(GetByApprovalStatusQuery request,  CancellationToken cancellationToken)
        {
            var Testimonials = await _testimonialRepository
            .GetByApprovalStatusAsync(request.ApprovalStatus, (ResultFilter)request, cancellationToken);

            var existingTestimonials = Testimonials.ToDto();

            _logger.LogInformation("Retrieved {@count} Testimonials", existingTestimonials.Count.ToString());
            return Result<List<TestimonialDto>>.Success(existingTestimonials);
        }

    }
}
