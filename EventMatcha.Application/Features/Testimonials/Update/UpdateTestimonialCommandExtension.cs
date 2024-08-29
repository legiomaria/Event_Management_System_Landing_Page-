using EventMatcha.Domain.Testimonials;

namespace EventMatcha.Application.Features.Testimonials.Update
{
    public static class UpdateTestimonialCommandExtension
    {
        public static Testimonial ToEntity(this UpdateTestimonialCommand command)
        {
            return Testimonial.UpdateTestimonial(
                command.Id,
                command.AuthorName,
                command.Text,
                command.AvatarUrl,
                command.UserType,
                command.ApprovalStatus.ToString(),
                command.ModifiedOn,
                command.ModifiedBy
                );
        }
    }
}
