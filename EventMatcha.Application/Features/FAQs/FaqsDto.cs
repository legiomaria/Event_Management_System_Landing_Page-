using EventMatcha.Domain.FAQs;

namespace EventMatcha.Application.Features.FAQs
{
    public class FaqsDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;
    }

    public static class FaqsExtension
    {
        public static FaqsDto ToDto(this Faqs faqs)
        {
            return new FaqsDto
            {
                Id = faqs.Id,
                Question = faqs.Question,
                Answer = faqs.Answer,
                Category = faqs.Category,
                ApprovalStatus = faqs.ApprovalStatus
            };
        }

        public static List<FaqsDto> ToDto(this IEnumerable<Faqs> entities)
        {
            List<FaqsDto> faqsDtos = [];

            foreach (var entity in entities)
            {
                faqsDtos.Add(entity.ToDto());
            }

            return faqsDtos;
        }
    }

}
