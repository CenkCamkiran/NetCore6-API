using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace APILayer.Controllers.Posts
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class PostsController : ControllerBase
	{

		//private readonly IConnectionMultiplexer _redisConnection;

		//public PostsController(IConnectionMultiplexer redisConnection)
		//{
		//	_redisConnection = redisConnection;
		//}

		[HttpGet]
		public object GetTopPosts()
		{

			PostsService PostsService = new PostsService();

			var cacheKey = "topPosts";
			List<Models.ControllerModels.Posts>? topPosts;
			topPosts = PostsService.GetTopPostsCache(cacheKey)?.ToList();

			if (topPosts == null)
			{
				var topPostsDB = PostsService.GetTopPosts().ToList();
				TimeSpan ttl = TimeSpan.FromMinutes(5); //5 minutes ttl

				string serializedPosts = JsonConvert.SerializeObject(topPostsDB);
				PostsService.SetTopPostsCache(cacheKey, serializedPosts, ttl);

			}

			return topPosts;
		}
	}
}
