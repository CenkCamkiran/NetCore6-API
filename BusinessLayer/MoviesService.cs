using DataAccessLayer.MongoDB.Interfaces;
using DataAccessLayer.Redis.Interfaces;
using Models.DataAccessLayerModels;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public List<Movie> GetAllMovies()
		{
			return _moviesRepository.GetAllMovies();
		}

		public List<Movie> GetAllMoviesCache(string key)
		{
			return _moviesCacheRepository.GetAllMoviesCache(key);
		}

		public Movie GetMovieCommentsByMovieId(string id)
		{
			return _moviesRepository.GetMovieCommentsByMovieId(id);
		}

		public Movie GetMovieCommentsByMovieIdCache(string id)
		{
			return _moviesRepository.GetMovieCommentsByMovieId(id);
		}

		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl)
		{
			_moviesCacheRepository.SetAllMoviesCache(key, jsonData, ttl);
		}
	}
}
