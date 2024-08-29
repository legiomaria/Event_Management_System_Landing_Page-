using EventMatcha.Domain.Testimonials;

namespace EventMatcha.Application.Features.Testimonials.Create
{
    public static class CreateTestimonialCommandExtension
    {
        public static Testimonial ToEntity(this CreateTestimonialCommand command)
        {
            return Testimonial.CreateTestimonial(
                command.AuthorName,
                command.Text,
                command.ApprovalStatus.ToString(),
                command.AvatarUrl,
                command.UserType,
                command.CreatedBy,
                command.CreatedOn
                );
        }
    }
}
