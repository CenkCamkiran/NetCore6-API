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

		private IConnectionMultiplexer _connectionMultiplexer;

		public MoviesCacheRepository(IConnectionMultiplexer connectionMultiplexer)
		{
			_connectionMultiplexer = connectionMultiplexer;
		}

		public bool ClearMoviesCache(string key)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);

			return redisCommand.Remove(key);
		}

		public List<Movie> GetAllMoviesCache(string key)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			RedisValue redisValue = redisCommand.Get(key);
			string dataByteArray = "";

			if (!redisValue.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(redisValue);

			List<Movie>? movieList = JsonConvert.DeserializeObject<List<Movie>>(dataByteArray);

			return movieList;
		}

		public MovieComments GetMovieCommentsByMovieIdCache(string key, string id)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			RedisValue redisValue = redisCommand.Get(key);
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
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);

			byte[]? dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			redisCommand.Add(key, dataByteArray, ttl);
		}
	}
}
