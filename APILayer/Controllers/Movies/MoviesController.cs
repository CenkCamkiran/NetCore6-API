using Helpers.AppExceptionHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.DataAccessLayerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using System.Net;

namespace APILayer.Controllers.Movies
{
	[Route("rest/api/v1/main/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		public List<Movie> GetAllMovies()
		{
			string cacheKey = "movies";
			List<Movie> movieList = _movieService.GetAllMoviesCache(cacheKey);

			if (movieList == null)
			{
				movieList = _movieService.GetAllMovies();

				if (movieList == null)
				{
					CustomAppError errorModel = new CustomAppError();
					errorModel.ErrorMessage = "Data not found";
					errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

					throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
				}

				string jsonData = JsonConvert.SerializeObject(movieList);
				TimeSpan ttl = TimeSpan.FromMinutes(5);

				_movieService.SetAllMoviesCache(cacheKey, jsonData, ttl);

				return movieList;

			}

			return movieList;
		}
	}
}
