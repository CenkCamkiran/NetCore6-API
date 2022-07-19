using DataAccessLayer.Redis.Infrastructure;
using DataAccessLayer.Redis.Interfaces;
using Models.ControllerModels;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace DataAccessLayer.Redis.Repository
{
	public class PostsCacheRepository : IPostsCacheRepository
	{

		public IEnumerable<Posts> GetTopPostsCache(string key)
		{
			RedisCommand<Posts> redisCommand = new RedisCommand<Posts>();

			return JsonConvert.DeserializeObject<IEnumerable<Posts>>(redisCommand.Get(key).ToString());
		}

		public void SetTopPostsCache(string key, string data, TimeSpan ttl)
		{
			RedisCommand<string> redisCommand = new RedisCommand<string>();

			redisCommand.Add(key, data, ttl);
		}
	}
}
