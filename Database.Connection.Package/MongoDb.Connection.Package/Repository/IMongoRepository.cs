using MongoDB.Driver;

namespace MongoDb.Connection.Package
{
    public interface IMongoRepository<T>
    {
        Task<T> FindOneASync(FilterDefinition<T> filter);
        Task<List<T>> FindManyAsync(FilterDefinition<T> filter);
        Task DeleteOneASync(FilterDefinition<T> filter);
        Task DeleteManyASync(FilterDefinition<T> filter);
        Task InsertOneAsync(T document);
        Task InsertManyAsync(List<T> document);
        Task<T> FindOneAndReplaceAsync(FilterDefinition<T> filter, T document);
        Task<List<T>> FindAllAsync();
        Task UpdateOneAsync(UpdateDefinition<T> update, FilterDefinition<T> filter);
        public bool IsConnected();
    }
}
