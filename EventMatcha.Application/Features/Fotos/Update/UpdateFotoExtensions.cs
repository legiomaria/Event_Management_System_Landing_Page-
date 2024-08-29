using EventMatcha.Domain.Fotos;

namespace EventMatcha.Application.Features.Fotos.Update
{
    internal static class UpdateFotoExtensions
    {
        public static Foto ToEntity(this UpdateFotoCommand command)
        {
            return Foto.UpdateFoto(
                command.Id,
                command.Name,
                command.Description,
                command.Path,
                command.AvatarUrl,
                command.ImageOwner,
                command.ApprovalStatus.ToString(),
                command.ModifiedOn,
                command.ModifiedBy         
                );
        }
    }
}
