using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APILayer.Controllers.Posts
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class PostsController : ControllerBase
	{

		private IPostsService _postsService;

		public PostsController(IPostsService postsService)
		{
			_postsService = postsService;
		}

		[HttpGet]
		public object GetTopPosts()
		{

			string cacheKey = "topPosts";
			List<Models.ControllerModels.Posts>? topPosts;
			topPosts = _postsService.GetTopPostsCache(cacheKey)?.ToList();

			if (topPosts == null)
			{
				var topPostsDB = _postsService.GetTopPosts().ToList();
				TimeSpan ttl = TimeSpan.FromMinutes(5); //5 minutes ttl

				string serializedPosts = JsonConvert.SerializeObject(topPostsDB);
				_postsService.SetTopPostsCache(cacheKey, serializedPosts, ttl);

				return topPostsDB;

			}

			return topPosts;
		}
	}
}
