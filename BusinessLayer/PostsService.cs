using BusinessLayer.Interfaces;
using DataAccessLayer.MongoDB.Repository;
using DataAccessLayer.Redis.Repository;
using Models.ControllerModels;
using StackExchange.Redis;

namespace BusinessLayer
{
	public class PostsService : IPostsService
	{

		private PostsCacheRepository postsCacheRepository;
		private PostsRepository postsRepository;


		public PostsService()
		{
			postsCacheRepository = new PostsCacheRepository();
			postsRepository = new PostsRepository();
		}

		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts()
		{
			return postsRepository.GetTopPosts();
		}

		public IEnumerable<Posts> GetTopPostsCache(string key)
		{
			return postsCacheRepository.GetTopPostsCache(key);
		}

		public void SetTopPostsCache(string key, string data, TimeSpan ttl)
		{
			postsCacheRepository.SetTopPostsCache(key, data, ttl);
		}
	}
}
