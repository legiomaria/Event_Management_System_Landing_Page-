using EventMatcha.Domain.Fotos;

namespace EventMatcha.Application.Features.Fotos.Create
{
    public static class CreateFotoCommandExtension
    {
        public static Foto ToEntity(this CreateFotoCommand command)
        {
            return Foto.CreateFoto(
                    command.Name,
                    command.Description,
                    command.Path,
                    command.AvatarUrl,
                    command.ImageOwner,
                    command.ApprovalStatus.ToString(),
                    command.CreatedOn,
                    command.CreatedBy
                    );
        }
    }
}
