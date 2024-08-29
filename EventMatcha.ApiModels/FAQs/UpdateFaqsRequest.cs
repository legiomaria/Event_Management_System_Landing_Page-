namespace EventMatcha.ApiModels.FAQs
{
    public class UpdateFaqsRequest : CreateFaqsRequest
    {
        public Guid Id { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
