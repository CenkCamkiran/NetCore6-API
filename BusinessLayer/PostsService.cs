using DataAccessLayer.MongoDB.Interfaces;
using DataAccessLayer.Redis.Interfaces;
using Models.ControllerModels;
using ServiceLayer.Interfaces;

namespace ServiceLayer
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
