using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMatcha.Application.Features.Testimonials.Update
{
    public class UpdateTestimonialCommandHandler 
        : IRequestHandler<UpdateTestimonialCommand, Result>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<UpdateTestimonialCommandHandler> _logger;
        public UpdateTestimonialCommandHandler(ITestimonialRepository testimonialRepository, 
            ILogger<UpdateTestimonialCommandHandler> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;   
        }
        public async Task<Result> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var existingTestimonial = await _testimonialRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (existingTestimonial == null)
            {
                return Result.Failure(TestimonialError.TestimonialNotFound);
            }

            var testimonialUpdate = request.ToEntity();
            var updateTestimonial = await _testimonialRepository
                   .UpdateAsync(testimonialUpdate);

            _logger.LogInformation("Testimonial {@id} updated successfully", updateTestimonial);

            return await Task.FromResult(Result<TestimonialDto>.Success(updateTestimonial.ToDto()));

        }
    }
}
