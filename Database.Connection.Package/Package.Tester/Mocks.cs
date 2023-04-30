using Microsoft.Extensions.DependencyInjection;
using MongoDb.Connection.Package;
using MongoDB.Driver;
using Package.Tester.MongoDB;
using Redis.Connection.Package.Repository;
using StackExchange.Redis;

namespace Tests.Bson
{
    public class Mocks
    {
        public static BsonClientAuthorization BsonClientAuthorizationFake => new()
        {
            ClientId = "testeClientId",
            ClientSecret = "testeClientSecret"
        };

        public static IServiceProvider BuildServiceProviderForMongo()
        {
            var mongoClient = new MongoClient("mongodb://root:kKQhMV1lNg@localhost:27018");
            var mongoCollection = mongoClient.GetDatabase("MagazineLuizaAuth").GetCollection<BsonClientAuthorization>("credentials");

            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IMongoClient>(c => mongoClient);
            services.AddScoped(c => mongoCollection);
            services.AddScoped<IMongoRepository<BsonClientAuthorization>, MongoRepository<BsonClientAuthorization>>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static IServiceProvider BuildServiceProviderForRedis()
        {
            var redisConnection = ConnectionMultiplexer.Connect("localhost:6379");

            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IConnectionMultiplexer>(r => redisConnection);
            services.AddScoped<IRedisRepository, RedisRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
