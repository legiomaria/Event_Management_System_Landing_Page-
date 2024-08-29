using EventMatcha.Domain.Primitives;

namespace EventMatcha.Domain.FAQs
{
    public class Faqs : Entity
    {
        public string Question { get; protected set; } = string.Empty;
        public string Answer { get; protected set; } = string.Empty;
        public string Category  { get; protected set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;

        private Faqs(
            string question,
            string answer,
            string category,
            string approvalStatus,
            DateTime createdOn,
            string createdBy
            )
        {
            Question = question;
            Answer = answer;
            Category = category;
            ApprovalStatus = approvalStatus;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            ModifiedOn = null;
            ModifiedBy = string.Empty;
        }

        private Faqs(
            Guid id,
            string question,
            string answer,
            string category,
            string approvalStatus,
            DateTime modifiedOn,
            string modifiedBy
            )
        {
            Id = id;
            Question = question;
            Answer = answer;
            Category = category;
            ApprovalStatus = approvalStatus;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }

        public static Faqs CreateFaqs(
            string question,
            string answer,
            string category,
            string approvalStatus,
            DateTime createdOn,
            string createdBy
            )
        {
            return new Faqs(
               question,
               answer,
               category,
               approvalStatus,
               createdOn,
               createdBy
                );
        }

        public static Faqs UpdateFaqs(
            Guid id,
            string question,
            string answer,
            string category,
            string approvalStatus,
            DateTime modifiedOn,
            string modifiedBy
          )
        {
            return new Faqs(
                id,
               question,
               answer,
               category,
               approvalStatus,
               modifiedOn,
               modifiedBy
                );

        }
    }
}
