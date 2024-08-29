using EventMatcha.Infrastructure.Options;
using MongoDB.Driver;

namespace EventMatcha.Infrastructure.Data
{
    public class DataContext
    {
        public IMongoDatabase MongoDatabase { set; get; }

        public DataContext(MongoDbOptions mongoDbOptions)
        {
            var client = new MongoClient(mongoDbOptions.ConnectionString);
            MongoDatabase = client.GetDatabase(mongoDbOptions.DatabaseName);
        }
    }
}
