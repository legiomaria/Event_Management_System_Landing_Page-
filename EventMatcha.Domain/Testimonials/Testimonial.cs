using EventMatcha.Domain.Primitives;


namespace EventMatcha.Domain.Testimonials
{
    public class Testimonial : Entity
    {
        public string AuthorName { get; protected set; } = string.Empty;
        public string Text { get; protected set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;
        public string AvatarUrl { get; protected set; } = string.Empty;
        public string UserType { get; protected set; } = string.Empty;

        private Testimonial(
            string authorName,
            string text,
            string approvalStatus,
            string avatarUrl,
            string userType,
            DateTime createdOn,
            string createdBy
        )
        {
            AuthorName = authorName;
            Text = text;
            ApprovalStatus = approvalStatus;
            AvatarUrl = avatarUrl;
            UserType = userType;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            ModifiedOn = null;
            ModifiedBy = string.Empty;
        }

        private Testimonial(
            Guid id,
            string authorName,
            string text,
            string approvalStatus,
            string avatarUrl,
            string userType,
            DateTime modifiedOn,
            string modifiedBy
            )
        {
            Id = id;
            AuthorName = authorName;
            Text = text;
            ApprovalStatus = approvalStatus;
            AvatarUrl = avatarUrl;
            UserType = userType;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }

        public static Testimonial CreateTestimonial(
            string authorName,
            string text,
            string approvalStatus,
            string avatarUrl,
            string userType,
            string createdBy,
            DateTime createdOn
            )
        {
            return new Testimonial(
            authorName,
            text,
            approvalStatus,
            avatarUrl,
            userType,
            createdOn,
            createdBy
                );
        }

        public static Testimonial UpdateTestimonial(
            Guid id,
            string authorName,
            string text,
            string approvalStatus,
            string avatarUrl,
            string userType,
            DateTime modifiedOn,
            string modifiedBy
          )
        {
            return new Testimonial(
               id,
               authorName,
               text,
               approvalStatus,
               avatarUrl,
               userType,
               modifiedOn,
               modifiedBy
                );
        }
    }
}
