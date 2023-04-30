using Microsoft.Extensions.DependencyInjection;
using Redis.Connection.Package.Repository;
using Tests.Bson;

namespace Package.Tester.MongoDB
{
    public class RedisConnectionTest
    {
        [Fact]
        public async Task Test()
        {
            string value = "";
            IServiceProvider serviceProvider = Mocks.BuildServiceProviderForRedis();
            var redis = serviceProvider.GetRequiredService<IRedisRepository>();
            var keyExists = await redis.AlreadyExist("1013-171199");

            if(keyExists)
                value = await redis.GetASync("1013-171199");

            Assert.NotNull(value);
        }
    }
}