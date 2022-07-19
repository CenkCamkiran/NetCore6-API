using StackExchange.Redis;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface IRedisCommand<TModel>
	{
		public void Add(string key, string data, TimeSpan ttl);
		public RedisValue Get(string key);
		public void Remove(string key);
		public bool Any(string key);
		public void Clear();
	}
}
