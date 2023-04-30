using StackExchange.Redis;

namespace Redis.Connection.Package.Repository
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IDatabase database;

        public RedisRepository(IConnectionMultiplexer redis)
        {
            this.database = redis.GetDatabase();
        }

        public async Task<bool> AlreadyExist(string hash)
        {
            return await database.KeyExistsAsync(hash);
        }

        public async Task<bool> InsertOrUpdateAsync(string hash, string value)
        {
            return await database.StringSetAsync(hash, value);
        }

        public async Task<bool> RemoveAsync(string hash)
        {
            return await database.KeyDeleteAsync(hash);
        }

        public async Task<string> GetASync(string hash)
        {
            var value = await database.StringGetAsync(hash);
            return value.ToString();
        }
    }
}