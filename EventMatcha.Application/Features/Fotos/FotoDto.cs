using EventMatcha.Domain.Fotos;


namespace EventMatcha.Application.Features.Fotos
{
    public class FotoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string ImageOwner { get; set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;

    }

    public static class FotoExtension
    {
        public static FotoDto ToDto(this Foto foto)
        {
            return new FotoDto
            {
                Id = foto.Id,
                Name = foto.Name,
                Description = foto.Description,
                Path = foto.Path,
                AvatarUrl = foto.AvatarUrl,
                ImageOwner = foto.ImageOwner,
                ApprovalStatus = foto.ApprovalStatus,
            };
        }

        public static List<FotoDto> ToDto(this IEnumerable<Foto> entities)
        {
            List<FotoDto> fotoDtos = [];

            foreach (var entity in entities)
            {
                fotoDtos.Add(entity.ToDto());
            }

            return fotoDtos;
        }
    }

}
