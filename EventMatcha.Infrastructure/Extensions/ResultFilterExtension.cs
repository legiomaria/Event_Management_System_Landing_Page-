using EventMatcha.Domain.Primitives;
using EventMatcha.Infrastructure.Consts;
using MongoDB.Bson;

namespace EventMatcha.Infrastructure.Extensions
{
    public static class ResultFilterExtension
    {

        public static BsonDocument ToBsonDocument(this ResultFilter filter) { 
       
            var dateQuery = new BsonDocument
            {
                {
                    Constants.QueryParams.CreatedOn , new BsonDocument
                    {
                        { Constants.QueryParams.GreaterThan, filter.From },
                        { Constants.QueryParams.LessThan, filter.To }
                    }
                },
                {
    // auto filter out documents that are flag as deleted (soft deleted)
            Constants.QueryParams.IsDeleted, new BsonDocument
            {
                { Constants.QueryParams.Matches, filter.IsDeleted }
            }
}
            };

            return dateQuery;
        }
    }
}
