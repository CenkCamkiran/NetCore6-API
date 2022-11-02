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
		private IRedisCommand _redisCommand;

		public PostsCacheRepository(IRedisCommand redisCommand)
		{
			_redisCommand = redisCommand;
		}

		public IEnumerable<Posts> GetTopPostsCache(string key)
		{

			RedisValue cacheResult = _redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheResult.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(cacheResult);

			IEnumerable<Posts>? Postslist = JsonConvert.DeserializeObject<IEnumerable<Posts>>(dataByteArray);

			return Postslist;

		}

		public void SetTopPostsCache(string key, string data, TimeSpan ttl)
		{

			byte[]? dataByteArray = Encoding.UTF8.GetBytes(data);

			_redisCommand.Add(key, dataByteArray, ttl);
		}
	}
}
