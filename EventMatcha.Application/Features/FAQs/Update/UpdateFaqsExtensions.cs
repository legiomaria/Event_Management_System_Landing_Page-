using EventMatcha.Domain.FAQs;

namespace EventMatcha.Application.Features.FAQs.Update
{
    internal static class UpdateFaqsExtensions
    {
        public static Faqs ToEntity(this UpdateFaqsCommand command)
        {
            return Faqs.UpdateFaqs(
                command.Id,
                command.Question,
                command.Answer,
                command.Category,
                command.ApprovalStatus.ToString(),
                command.ModifiedOn,
                command.ModifiedBy
                
                );
        }
    }
}
