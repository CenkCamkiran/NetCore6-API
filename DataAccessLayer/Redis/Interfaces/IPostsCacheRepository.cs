using Models.ControllerModels;
using StackExchange.Redis;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface IPostsCacheRepository
	{
		public IEnumerable<Posts> GetTopPostsCache(string key);
		public void SetTopPostsCache(string key, string data, TimeSpan ttl);
	}
}
