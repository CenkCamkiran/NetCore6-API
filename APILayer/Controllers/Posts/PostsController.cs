using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;

namespace APILayer.Controllers.Posts
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class PostsController : ControllerBase
	{

		private CustomersService customersService;

		[HttpGet]
		public Models.ControllerModels.Posts GetTopPosts()
		{

			var cacheKey = "topPosts";
			List<Models.ControllerModels.Posts> Posts = new List<Models.ControllerModels.Posts>();

			return null;
		}
	}
}
