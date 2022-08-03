using Helpers.AppExceptionHelpers;
using Helpers.StringHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.DataAccessLayerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using System.Net;

namespace APILayer.Controllers.Comments
{
	[Route("rest/api/v1/main/[controller]")]
	[ApiController]
	public class MovieCommentsController : ControllerBase
	{

		private IMovieService _movieService;

		public MovieCommentsController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet("Id/{Id}")]
		public object GetMovieCommentsByMovieId(string id)
		{
			id.ControlObjectID(id);

			string cacheKey = "movieComments";
			MovieComments moviesCommentsCache = _movieService.GetMovieCommentsByMovieIdCache(cacheKey, id);

			if (moviesCommentsCache == null)
			{
				moviesCommentsCache = _movieService.GetMovieCommentsByMovieId(id);

				if (moviesCommentsCache == null)
				{
					CustomAppError errorModel = new CustomAppError();
					errorModel.ErrorMessage = "Data not found";
					errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

					throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
				}

				List<MovieComments> moviesComments = _movieService.GetAllMoviesWithComment();

				string jsonData = JsonConvert.SerializeObject(moviesComments);
				TimeSpan ttl = TimeSpan.FromMinutes(5);

				_movieService.ClearMoviesCache(cacheKey);
				_movieService.SetAllMoviesCache(cacheKey, jsonData, ttl);

			}

			return moviesCommentsCache;
		}
	}
}
