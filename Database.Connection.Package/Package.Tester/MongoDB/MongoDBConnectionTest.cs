using Microsoft.Extensions.DependencyInjection;
using MongoDb.Connection.Package;
using Tests.Bson;

namespace Package.Tester.MongoDB
{
    public class MongoDBConnectionTest
    {
        [Fact]
        public async Task Test()
        {
            IServiceProvider serviceProvider = Mocks.BuildServiceProviderForMongo();
            var mongo = serviceProvider.GetRequiredService<IMongoRepository<BsonClientAuthorization>>();
            var docs = await mongo.FindAllAsync();
            Assert.NotNull(docs);
        }
    }
}