using EventMatcha.Domain.Primitives;
using EventMatcha.Domain.Testimonials;
using EventMatcha.Infrastructure.Consts;
using EventMatcha.Infrastructure.Data;
using MongoDB.Bson;
using Testimonial = EventMatcha.Domain.Testimonials.Testimonial;
using MongoDB.Driver;
using EventMatcha.Infrastructure.Extensions;


namespace EventMatcha.Infrastructure.Repositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IMongoCollection<Testimonial> _collection;
        public TestimonialRepository(DataContext dataContext)
        {
            _collection = dataContext
                              .MongoDatabase
                              .GetCollection<Testimonial>(Constants.Collections.Testimonial);
        }

        public async Task<Testimonial> CreateAsync(Testimonial testimonial, CancellationToken cancellationToken = default)
        {
            //testimonial.ApprovalStatus = ApprovalStatusEnum.Default.ToString();
            _collection.InsertOne(testimonial, null, cancellationToken);
            return await Task.FromResult(testimonial);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var oldValue = Builders<Testimonial>.Filter.Eq(p => p.Id, id);
            var builder = Builders<Testimonial>.Update;

            var update = builder
                         .Set(prop => prop.ModifiedBy, "User")
                         .Set(prop => prop.IsDeleted, true)
                         .Set(prop => prop.ModifiedOn, DateTime.UtcNow);

            var updateResult = await _collection.UpdateOneAsync(oldValue, update, null, cancellationToken);

            return await Task.FromResult(updateResult.IsAcknowledged);

        }
        public async Task<bool> ExistAsync(Testimonial testimonial, CancellationToken cancellationToken = default)
        {
            Testimonial? result = null;
            try
            {
                var filter = Builders<Testimonial>.Filter;
                var testimonialTitleFilter = filter.Eq("Title", testimonial.AuthorName);

                result = await _collection
                    .Find(testimonialTitleFilter)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return result != null;
        }

        public async Task<IEnumerable<Testimonial>> GetAllAsync(ResultFilter filter, CancellationToken cancellationToken = default)
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

        public async Task<IEnumerable<Testimonial>> GetByApprovalStatusAsync(string approvalStatus, ResultFilter filter, CancellationToken cancellationToken = default)
        {
            var builderFilter = Builders<Testimonial>.Filter;
            var approvalFilter = builderFilter.Eq(u => u.ApprovalStatus, approvalStatus);

            var result = await _collection
                .Find(approvalFilter)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Testimonial> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var builder = Builders<Testimonial>.Filter;
            var testimonialIdFilter = builder.Eq(p => p.Id, id);

            var result = await _collection
                .Find(testimonialIdFilter)
                .SingleOrDefaultAsync(cancellationToken);

            return result;
        }

        public async Task<Testimonial> UpdateAsync(Testimonial testimonial, CancellationToken cancellationToken = default)
        {
            var oldValue = Builders<Testimonial>.Filter.Eq(testimonial => testimonial.Id, testimonial.Id);
            var builder = Builders<Testimonial>.Update;

            var update = builder
                            .Set(prop => prop.AuthorName, testimonial.AuthorName)
                            .Set(prop => prop.Text, testimonial.Text)
                            .Set(prop => prop.ApprovalStatus, testimonial.ApprovalStatus)
                            .Set(prop => prop.AvatarUrl, testimonial.AvatarUrl)
                            .Set(prop => prop.UserType, testimonial.UserType)
                            .Set(prop => prop.ModifiedBy, testimonial.ModifiedBy)
                            .Set(prop => prop.ModifiedOn, testimonial.ModifiedOn);

            await _collection.UpdateOneAsync(oldValue, update, null, cancellationToken);
            return testimonial;

        }
    }
}
