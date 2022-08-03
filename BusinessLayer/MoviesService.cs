using DataAccessLayer.MongoDB.Interfaces;
using DataAccessLayer.Redis.Interfaces;
using Models.DataAccessLayerModels;
using ServiceLayer.Interfaces;

namespace ServiceLayer
{
	public class MoviesService : IMovieService
	{
		private IMoviesRepository _moviesRepository;
		private IMoviesCacheRepository _moviesCacheRepository;

		public MoviesService(IMoviesRepository moviesRepository, IMoviesCacheRepository moviesCacheRepository)
		{
			_moviesRepository = moviesRepository;
			_moviesCacheRepository = moviesCacheRepository;
		}

		public bool ClearMoviesCache(string key)
		{
			return _moviesCacheRepository.ClearMoviesCache(key);
		}

		public List<Movie> GetAllMovies()
		{
			return _moviesRepository.GetAllMovies();
		}

		public List<Movie> GetAllMoviesCache(string key)
		{
			return _moviesCacheRepository.GetAllMoviesCache(key);
		}

		public List<MovieComments> GetAllMoviesWithComment()
		{
			return _moviesRepository.GetAllMoviesWithComment();
		}

		public MovieComments GetMovieCommentsByMovieId(string id)
		{
			return _moviesRepository.GetMovieCommentsByMovieId(id);
		}

		public MovieComments GetMovieCommentsByMovieIdCache(string key, string id)
		{
			return _moviesCacheRepository.GetMovieCommentsByMovieIdCache(key, id);
		}

		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl)
		{
			_moviesCacheRepository.SetAllMoviesCache(key, jsonData, ttl);
		}
	}
}
