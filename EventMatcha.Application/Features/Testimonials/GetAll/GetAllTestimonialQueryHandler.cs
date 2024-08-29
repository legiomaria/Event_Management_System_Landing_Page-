using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Testimonials.GetAll
{
    public class GetAllTestimonialQueryHandler
        : IRequestHandler<GetAllTestimonialQuery, Result>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<GetAllTestimonialQueryHandler> _logger;
        public GetAllTestimonialQueryHandler(ITestimonialRepository testimonialRepository,
            ILogger<GetAllTestimonialQueryHandler> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;
        }
        public async Task<Result> Handle(GetAllTestimonialQuery request, CancellationToken cancellationToken)
        {
            var Testimonials = await _testimonialRepository
                    .GetAllAsync(request, cancellationToken);

            var testimonialExist = Testimonials.ToDto();

            _logger.LogInformation("Retrieved { @count } testimonials", testimonialExist.Count.ToString());

            return Result<List<TestimonialDto>>.Success(testimonialExist);
        }
    }
}
