namespace EventMatcha.ApiModels.Testimonials
{
    public class UpdateTestimonialRequest : CreateTestimonialRequest
    {
        public Guid Id { get; set; }
        public string Modified { get; set; } = string.Empty;
    }
}
