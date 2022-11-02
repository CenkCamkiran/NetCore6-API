using DataAccessLayer.Redis.Interfaces;
using StackExchange.Redis;

namespace DataAccessLayer.Redis.Infrastructure
{
	public class RedisCommand : IRedisCommand
	{
		private readonly IConnectionMultiplexer _connectionMultiplexer;
		private readonly IDatabase redisDatabase;

		public RedisCommand(IConnectionMultiplexer connectionMultiplexer)
		{
			_connectionMultiplexer = connectionMultiplexer;	
			redisDatabase = _connectionMultiplexer.GetDatabase();
		}

		public void Add(string key, byte[]? data, TimeSpan ttl)
		{
			redisDatabase.StringSet(key, data, ttl);
		}

		public bool Any(string key)
		{
			return redisDatabase.KeyExists(key);
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public RedisValue Get(string key)
		{
			return redisDatabase.StringGet(key);
		}

		public bool Remove(string key)
		{
			return redisDatabase.KeyDelete(key);
		}
	}
}
