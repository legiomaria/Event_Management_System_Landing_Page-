using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Testimonials.Delete
{
    public class DeleteTestimonialCommandHandler 
        : IRequestHandler<DeleteTestimonialCommand, Result>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<DeleteTestimonialCommandHandler> _logger;  
        public DeleteTestimonialCommandHandler(ITestimonialRepository testimonialRepository,
            ILogger<DeleteTestimonialCommandHandler> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;   
        }
        public async Task<Result> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var existingTestimonial = await _testimonialRepository
                    .GetByIdAsync(request.Id, cancellationToken);

            if (existingTestimonial == null)
            {
                return Result.Failure(TestimonialError.TestimonialNotFound);
            }

            var deleteTestimonial = await _testimonialRepository
                    .DeleteAsync(request.Id, cancellationToken);

            _logger.LogInformation("Testimonial { @id } deleted successfully", deleteTestimonial);

            return Result<bool>.Success(deleteTestimonial);
        }
    }
}
