using EventMatcha.Domain.Testimonials;

namespace EventMatcha.Application.Features.Testimonials
{
    public class TestimonialDto
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
    }

    public static class TestimonialExtension
    {
        public static TestimonialDto ToDto(this Testimonial testimonial)
        {
            return new TestimonialDto
            {
                Id = testimonial.Id,
                AuthorName = testimonial.AuthorName,
                Text = testimonial.Text,
                ApprovalStatus = testimonial.ApprovalStatus,
                AvatarUrl = testimonial.AvatarUrl,
                UserType = testimonial.UserType,
            };
        }

        public static List<TestimonialDto> ToDto(this IEnumerable<Testimonial> entities)
        {
            List<TestimonialDto> testimonialDtos = [];

            foreach (var entity in entities)
            {
                testimonialDtos.Add(entity.ToDto());
            }

            return testimonialDtos;
        }
    }
}
