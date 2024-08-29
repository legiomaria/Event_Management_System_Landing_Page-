using EventMatcha.Domain.Primitives;

namespace EventMatcha.Domain.Fotos
{
    public class Foto : Entity
    {
        public string Name { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public string Path { get; protected set; } = string.Empty;
        public string AvatarUrl { get; protected set; } = string.Empty;
        public string ImageOwner { get; protected set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;

        private Foto(
            string name,
            string description,
            string path,
            string avatarUrl,
            string imageOwner,
            string approvalStatus,
            DateTime createdOn,
            string createdBy
            
        )
        {
            Name = name;
            Description = description;
            Path = path;
            AvatarUrl = avatarUrl;
            ImageOwner = imageOwner;
            ApprovalStatus = approvalStatus;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            ModifiedOn = null;
            ModifiedBy = string.Empty;
        }

        private Foto(
            Guid id,
            string name,
            string description,
            string path,
            string avatarUrl,
            string imageOwner,
            string approvalStatus,
            DateTime modifiedOn,
            string modifiedBy
            )
        {
            Id = id;
            Name = name;
            Description = description;
            Path = path;
            AvatarUrl = avatarUrl;
            ImageOwner = imageOwner;
            ApprovalStatus = approvalStatus;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
        }

        public static Foto CreateFoto(
            string name,
            string description,
            string path,
            string avatarUrl,
            string imageOwner,
            string approvalStatus,
            DateTime createdOn,
            string createdBy
            )
        {
            return new Foto(
            name,
            description,
            path,
            avatarUrl,
            imageOwner,
            approvalStatus,
            createdOn,
            createdBy
                );
        }

        public static Foto UpdateFoto(
            Guid id,
            string name,
            string description,
            string path,
            string avatarUrl,
            string imageOwner,
            string approvalStatus,
            DateTime modifiedOn,
            string modifiedBy
          )
        {
            return new Foto(
               id,
               name,
               description,
               path,
               avatarUrl,
               imageOwner,
               approvalStatus,
               modifiedOn,
               modifiedBy
                );
        }
    }
}
