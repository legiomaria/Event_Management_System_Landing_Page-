using EventMatcha.Domain.FAQs;

namespace EventMatcha.Application.Features.FAQs.Create
{
    public static class CreateFaqsCommandExtension
    {
        public static Faqs ToEntity(this CreateFaqsCommand command)
        {
            return Faqs.CreateFaqs(
                    command.Question,
                    command.Answer,
                    command.Category.ToString(),
                    command.ApprovalStatus.ToString(),
                    command.CreatedOn,
                    command.CreatedBy
                    );
        }
    }
}
