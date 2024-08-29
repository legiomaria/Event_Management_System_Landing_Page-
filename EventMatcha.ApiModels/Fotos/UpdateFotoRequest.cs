namespace EventMatcha.ApiModels.Fotos
{
    public class UpdateFotoRequest : CreateFotoRequest
    {
        public Guid Id { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
