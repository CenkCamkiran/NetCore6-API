using DataAccessLayer.Redis.Infrastructure;
using DataAccessLayer.Redis.Interfaces;
using Models.DataAccessLayerModels;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Redis.Repository
{
	public class MoviesCacheRepository : IMoviesCacheRepository
	{

		private IConnectionMultiplexer _connectionMultiplexer;

		public MoviesCacheRepository(IConnectionMultiplexer connectionMultiplexer)
		{
			_connectionMultiplexer = connectionMultiplexer;
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

		public Movie GetMovieCommentsByMovieIdCache(string key, string id)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			RedisValue redisValue = redisCommand.Get(key);
			string dataByteArray = "";

			if (!redisValue.IsNullOrEmpty)

				return null;

			return null;

		}

		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);

			byte[]? dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			redisCommand.Add(key, dataByteArray, ttl);
		}
	}
}
