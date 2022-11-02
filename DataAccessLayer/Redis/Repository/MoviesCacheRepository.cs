using DataAccessLayer.Redis.Infrastructure;
using DataAccessLayer.Redis.Interfaces;
using Models.DataAccessLayerModels;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace DataAccessLayer.Redis.Repository
{
	public class MoviesCacheRepository : IMoviesCacheRepository
	{

		private IRedisCommand _redisCommand;

		public MoviesCacheRepository(IRedisCommand redisCommand)
		{
			_redisCommand = redisCommand;
		}

		public bool ClearMoviesCache(string key)
		{

			return _redisCommand.Remove(key);
		}

		public List<Movie> GetAllMoviesCache(string key)
		{
			RedisValue redisValue = _redisCommand.Get(key);
			string dataByteArray = "";

			if (!redisValue.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(redisValue);

			List<Movie>? movieList = JsonConvert.DeserializeObject<List<Movie>>(dataByteArray);

			return movieList;
		}

		public MovieComments GetMovieCommentsByMovieIdCache(string key, string id)
		{
			RedisValue redisValue = _redisCommand.Get(key);
			string dataByteArray = "";

			if (!redisValue.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(redisValue);

			MovieComments? movie = null;
			List<MovieComments>? movieList = JsonConvert.DeserializeObject<List<MovieComments>>(dataByteArray);

			if (movieList != null)
				movie = movieList.Where(movie => movie._id == id).SingleOrDefault();

			return movie;
		}

		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl)
		{

			byte[]? dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			_redisCommand.Add(key, dataByteArray, ttl);
		}
	}
}
