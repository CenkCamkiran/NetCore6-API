using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APILayer.Controllers.Posts
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class PostsController : ControllerBase
	{

		private PostsService PostsService;

		public PostsController()
		{
			PostsService = new PostsService();
		}

		[HttpGet]
		public object GetTopPosts()
		{

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
