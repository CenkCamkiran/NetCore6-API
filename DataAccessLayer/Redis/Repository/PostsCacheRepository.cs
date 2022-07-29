using DataAccessLayer.Redis.Infrastructure;
using DataAccessLayer.Redis.Interfaces;
using Models.ControllerModels;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace DataAccessLayer.Redis.Repository
{
	public class PostsCacheRepository : IPostsCacheRepository
	{
		private readonly IConnectionMultiplexer _redisConnection;

		public PostsCacheRepository(IConnectionMultiplexer redisConnection)
		{
			_redisConnection = redisConnection;
		}

		public IEnumerable<Posts> GetTopPostsCache(string key)
		{

			RedisCommand redisCommand = new RedisCommand(_redisConnection);

			RedisValue cacheResult = redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheResult.IsNullOrEmpty)
			{
				dataByteArray = Encoding.UTF8.GetString(cacheResult);
			}

			IEnumerable<Posts>? Postslist = JsonConvert.DeserializeObject<IEnumerable<Posts>>(dataByteArray);

			return Postslist;

		}

		public void SetTopPostsCache(string key, string data, TimeSpan ttl)
		{

			byte[]? dataByteArray = Encoding.UTF8.GetBytes(data);
			RedisCommand redisCommand = new RedisCommand(_redisConnection);

			redisCommand.Add(key, dataByteArray, ttl);
		}
	}
}
