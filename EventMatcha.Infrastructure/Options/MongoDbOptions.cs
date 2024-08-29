namespace EventMatcha.Infrastructure.Options
{
    public class MongoDbOptions
    {
        public const string Section = "MongoDbOptions";
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
