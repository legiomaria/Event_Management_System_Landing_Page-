using EventMatcha.Infrastructure.Data;
using EventMatcha.Domain.Fotos;
using EventMatcha.Domain.Primitives;
using EventMatcha.Infrastructure.Consts;
using MongoDB.Bson;
using MongoDB.Driver;
using Foto = EventMatcha.Domain.Fotos.Foto;
using EventMatcha.Infrastructure.Extensions;

namespace EventMatcha.Infrastructure.Repositories
{
    public class FotoRepository : IFotoRepository
    {
        private readonly IMongoCollection<Foto> _collection;

        public FotoRepository(DataContext dataContext)
        {
            _collection = dataContext
                            .MongoDatabase
                            .GetCollection<Foto>(Constants.Collections.Foto);
        }

        public async Task<Foto> CreateAsync(Foto foto, CancellationToken cancellationToken = default)
        {
            _collection.InsertOne(foto, null, cancellationToken);
            return await Task.FromResult(foto);
        }
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var oldValue = Builders<Foto>.Filter.Eq(foto => foto.Id, id);
            var builder = Builders<Foto>.Update;

            var update = builder
                         .Set(prop => prop.ModifiedBy, "User")
                         .Set(prop => prop.IsDeleted, true)
                         .Set(prop => prop.ModifiedOn, DateTime.UtcNow);

            var updateResult = await _collection.UpdateOneAsync(oldValue, update, null, cancellationToken);

            return await Task.FromResult(updateResult.IsAcknowledged);
        }

        public async Task<bool> ExistAsync(Foto foto, CancellationToken cancellationToken = default)
        {
            Foto? result = null;
            try
            {
                var filter = Builders<Foto>.Filter;
                var fotoTitleFilter = filter.Eq("Title", foto.Name);

                result = await _collection
                   .Find(fotoTitleFilter)
                    .SingleOrDefaultAsync(cancellationToken);
            }
            catch (Exception ex)
            {

            }

            return result != null;
        }
        public async Task<IEnumerable<Foto>> GetByApprovalStatusAsync(string approvalStatus, ResultFilter filter, CancellationToken cancellationToken = default)
        {
            var builderFilter = Builders<Foto>.Filter;
            var approvalFilter = builderFilter.Eq(u => u.ApprovalStatus, approvalStatus);

            var result = await _collection
                .Find(approvalFilter)
                .ToListAsync(cancellationToken);

            return result;
        }
        public async Task<IEnumerable<Foto>> GetAllAsync(ResultFilter filter, CancellationToken cancellationToken = default)
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


        public async Task<Foto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var builder = Builders<Foto>.Filter;
            var fotoIdFilter = builder.Eq(u => u.Id, id);

            var result = await _collection
                .Find(fotoIdFilter)
                .SingleOrDefaultAsync(cancellationToken);

            return result;
        }



        public async Task<Foto> UpdateAsync(Foto foto, CancellationToken cancellationToken = default)
        {
            var oldValue = Builders<Foto>.Filter.Eq(foto => foto.Id, foto.Id);
            var builder = Builders<Foto>.Update;

            var update = builder
                         .Set(prop => prop.Name, foto.Name)
                         .Set(prop => prop.Description, foto.Description)
                         .Set(prop => prop.Path, foto.Path)
                         .Set(prop => prop.AvatarUrl, foto.AvatarUrl)
                         .Set(prop => prop.ImageOwner, foto.ImageOwner)
                         .Set(prop => prop.ModifiedBy, foto.ModifiedBy)
                         .Set(prop => prop.ModifiedOn, foto.ModifiedOn);


            await _collection.UpdateOneAsync(oldValue, update, null, cancellationToken);

            return await Task.FromResult(foto);
        }
    }
}
