using MongoDB.Driver;
namespace MongoDb.Connection.Package
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        private IMongoCollection<T> collection;
        private IMongoClient client;

        public MongoRepository(IMongoClient mongoClient, IMongoCollection<T> collection)
        {
            this.collection = collection;
            this.client = mongoClient;
        }

        public bool IsConnected()
        {
            try
            {
                client.ListDatabaseNames().ToList();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> FindOneASync(FilterDefinition<T> filter)
        {
            var doc = collection.Find(filter).Skip(0).Limit(1);
            var bson = await doc.FirstOrDefaultAsync();
            return bson;
        }

        public async Task<List<T>> FindManyAsync(FilterDefinition<T> filter)
        {
            var doc = await collection.FindAsync(filter);
            return doc.ToList();
        }

        public async Task DeleteOneASync(FilterDefinition<T> filter)
        {
            await collection.DeleteOneAsync(filter);
        }

        public async Task DeleteManyASync(FilterDefinition<T> filter)
        {
            await collection.DeleteManyAsync(filter);
        }

        public async Task InsertOneAsync(T document)
        {
            await collection.InsertOneAsync(document);
        }

        public async Task<T> FindOneAndReplaceAsync(FilterDefinition<T> filter, T document)
        {
            return await collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task<List<T>> FindAllAsync()
        {
            var documents = await collection.FindAsync(_ => true);
            return documents.ToList();
        }

        public async Task InsertManyAsync(List<T> document)
        {
            await collection.InsertManyAsync(document);
        }

        public async Task UpdateOneAsync(UpdateDefinition<T> update, FilterDefinition<T> filter)
        {
            await collection.UpdateOneAsync(filter, update);
        }
    }
}