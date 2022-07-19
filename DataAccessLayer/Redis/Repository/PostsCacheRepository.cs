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

		public IEnumerable<Posts> GetTopPostsCache(string key)
		{
			RedisCommand<Posts> redisCommand = new RedisCommand<Posts>();

			RedisValue cacheResult = redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheResult.IsNullOrEmpty)
			{
				dataByteArray = Encoding.UTF8.GetString(cacheResult);
			}

			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore
			};

			return JsonConvert.DeserializeObject<IEnumerable<Posts>>(cacheResult, settings);

		}

		public void SetTopPostsCache(string key, string data, TimeSpan ttl)
		{

			byte[]? dataByteArray = Encoding.UTF8.GetBytes(data);
			RedisCommand<string> redisCommand = new RedisCommand<string>();

			redisCommand.Add(key, dataByteArray, ttl);
		}
	}
}
