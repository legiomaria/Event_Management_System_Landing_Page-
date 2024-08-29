using EventMatcha.Infrastructure.Data;
using EventMatcha.Domain.FAQs;
using EventMatcha.Domain.Primitives;
using EventMatcha.Infrastructure.Consts;
using MongoDB.Bson;
using MongoDB.Driver;
using Faqs = EventMatcha.Domain.FAQs.Faqs;
using EventMatcha.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;


namespace EventMatcha.Infrastructure.Repositories
{
    public class FaqsRepository : IFaqsRepository
    {
        private readonly IMongoCollection<Faqs> _collection;

        public FaqsRepository(DataContext dataContext)
        {
            _collection = dataContext
                            .MongoDatabase
                            .GetCollection<Faqs>(Constants.Collections.Faqs);
        }

        public async Task<Faqs> CreateAsync(Faqs faqs, CancellationToken cancellationToken = default)
        {
            _collection.InsertOne(faqs, null, cancellationToken);
            return await Task.FromResult(faqs);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var oldValue = Builders<Faqs>.Filter.Eq(faqs => faqs.Id, id);
            var builder = Builders<Faqs>.Update;

            var update = builder
                         .Set(prop => prop.ModifiedBy, "User")
                         .Set(prop => prop.IsDeleted, true)
                         .Set(prop => prop.ModifiedOn, DateTime.UtcNow);

            var updateResult = await _collection.UpdateOneAsync(oldValue, update, null, cancellationToken);

            return await Task.FromResult(updateResult.IsAcknowledged);
        }

        public async Task<bool> ExistAsync(Faqs faqs, CancellationToken cancellationToken = default)
        {
            Faqs? result = null;
            try
            {
                var filter = Builders<Faqs>.Filter;
                var faqsTitleFilter = filter.Eq("Title", faqs.Id);

                result = await _collection
                   .Find(faqsTitleFilter)
                    .SingleOrDefaultAsync(cancellationToken);
            }
            catch (Exception)
            {

            }

            return result != null;
        }
        public async Task<IEnumerable<Faqs>> GetAllAsync(ResultFilter filter, CancellationToken cancellationToken = default)
        {
            var dateQuery = filter.ToBsonDocument();
            var result = await _collection
                .Find(dateQuery)
                .SortBy(u => u.CreatedOn)
                .Skip(filter.Page * filter.PageSize)
                .Limit(filter.PageSize)
                .ToListAsync(cancellationToken);

            return result;
        }
        public async Task<IEnumerable<Faqs>> GetByFaqsCategoryAsync(string category, ResultFilter filter, CancellationToken cancellationToken = default)
        {
            var builderFilter = Builders<Faqs>.Filter;
            var CategoryFilter = builderFilter.Eq(u => u.Category, category);

            var result = await _collection
            .Find(CategoryFilter)
            .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Faqs>> GetByApprovalStatusAsync(string approvalStatus, ResultFilter filter, CancellationToken cancellationToken = default)
        {
            var builderFilter = Builders<Faqs>.Filter;
            var approvalFilter = builderFilter.Eq(u => u.ApprovalStatus, approvalStatus);

            var result = await _collection
                .Find(approvalFilter)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Faqs> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var builder = Builders<Faqs>.Filter;
            var faqsIdFilter = builder.Eq(u => u.Id, id);

            var result = await _collection
                .Find(faqsIdFilter)
                .SingleOrDefaultAsync(cancellationToken);

            return result;
        }

        public async Task<Faqs> UpdateAsync(Faqs faqs, CancellationToken cancellationToken = default)
        {
            var oldValue = Builders<Faqs>.Filter.Eq(faqs => faqs.Id, faqs.Id);
            var builder = Builders<Faqs>.Update;

            var update = builder
                         .Set(prop => prop.Question, faqs.Question)
                         .Set(prop => prop.Answer, faqs.Answer)
                         .Set(prop => prop.Category, faqs.Category)
                         .Set(prop => prop.ModifiedBy, faqs.ModifiedBy)
                         .Set(prop => prop.ModifiedOn, faqs.ModifiedOn);

            await _collection.UpdateOneAsync(oldValue, update, null, cancellationToken);

            return await Task.FromResult(faqs);
        }

    }
}