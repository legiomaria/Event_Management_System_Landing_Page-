using EventMatcha.Shared;

namespace EventMatcha.Domain.Testimonials
{
    public class TestimonialError
    {
        public static readonly Error TestimonialExist = new("Testimonial.TestimonialExist", "Testimonial already exist");
        public static readonly Error TestimonialNotFound = new("Testimonial.TestimonialNotFound", "Testimonial does not exist");
    }
}
