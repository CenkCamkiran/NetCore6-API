using BusinessLayer.Interfaces;
using DataAccessLayer.MongoDB.Interfaces;
using DataAccessLayer.MongoDB.Repository;
using DataAccessLayer.Redis.Interfaces;
using DataAccessLayer.Redis.Repository;
using Models.ControllerModels;
using StackExchange.Redis;

namespace BusinessLayer
{
	public class PostsService : IPostsService
	{

		private IPostsRepository _postsRepository;
		private IPostsCacheRepository _postsCacheRepository;

		public PostsService(IPostsRepository postsRepository, IPostsCacheRepository postsCacheRepository)
		{
			_postsRepository = postsRepository;
			_postsCacheRepository = postsCacheRepository;
		}

		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts()
		{
			return _postsRepository.GetTopPosts();
		}

		public IEnumerable<Posts> GetTopPostsCache(string key)
		{
			return _postsCacheRepository.GetTopPostsCache(key);
		}

		public void SetTopPostsCache(string key, string data, TimeSpan ttl)
		{
			_postsCacheRepository.SetTopPostsCache(key, data, ttl);
		}
	}
}
