using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers.Movies
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		[HttpGet]
		public object GetAllMovies()
		{
			""
			return null;
		}
	}
}
