using EventMatcha.Shared;

namespace EventMatcha.Domain.Fotos
{
    public class FotoErrors
    {
        public static readonly Error FotoExist = new("Foto.FotoExist", "Foto already exist");
        public static readonly Error FotoNotFound = new("Foto.FotoNotFound", "Foto does not exist");
    }
}
