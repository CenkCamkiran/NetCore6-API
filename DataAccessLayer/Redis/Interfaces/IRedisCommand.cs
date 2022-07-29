using StackExchange.Redis;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface IRedisCommand
	{
		public void Add(string key, byte[]? data, TimeSpan ttl);
		public RedisValue Get(string key);
		public void Remove(string key);
		public bool Any(string key);
		public void Clear();
	}
}
