namespace Redis.Connection.Package.Repository
{
    public interface IRedisRepository
    {
        Task<bool> AlreadyExist(string hash);
        Task<bool> InsertOrUpdateAsync(string hash, string value);
        Task<bool> RemoveAsync(string hash);
        Task<string> GetASync(string hash);
    }
}
