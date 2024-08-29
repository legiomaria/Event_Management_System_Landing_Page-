using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Testimonials.GetById
{
    public class GetTestimonialByIdQueryHandler
        : IRequestHandler<GetTestimonialByIdQuery, Result>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<GetTestimonialByIdQueryHandler> _logger;

        public GetTestimonialByIdQueryHandler(ITestimonialRepository testimonialRepository, ILogger<GetTestimonialByIdQueryHandler> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;
        }

        
        public async Task<Result> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonialExist = await _testimonialRepository
                    .GetByIdAsync(request.Id, cancellationToken);

            if (testimonialExist == null)
            {
                return Result.Failure(TestimonialError.TestimonialNotFound);
            }

            _logger.LogInformation("Details of testimonial {@Id} retrieved", request.Id);

            var testimonial = testimonialExist.ToDto();

            return Result<TestimonialDto>.Success(testimonial);  
        }
    }
}
