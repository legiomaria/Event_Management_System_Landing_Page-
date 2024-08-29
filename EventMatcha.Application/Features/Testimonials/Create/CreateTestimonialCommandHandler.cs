using EventMatcha.Application.Features.Fotos;
using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Testimonials.Create
{
    public class CreateTestimonialCommandHandler
        : IRequestHandler<CreateTestimonialCommand, Result>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<CreateTestimonialCommandHandler> _logger;
        public CreateTestimonialCommandHandler(ITestimonialRepository testimonialRepository, ILogger<CreateTestimonialCommandHandler> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;
        }
        public async Task<Result> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = request.ToEntity();

            var testimonialExist = await _testimonialRepository.ExistAsync(testimonial, cancellationToken);

            if (testimonialExist)
            {
                return Result.Failure(TestimonialError.TestimonialExist);
            }

            var testimonialCreated = await _testimonialRepository.CreateAsync(testimonial, cancellationToken);

            _logger.LogInformation("Testimonial { @Id } created", testimonialCreated.Id);

            return Result<TestimonialDto>.Success(testimonialCreated.ToDto());
        }
    }
}
