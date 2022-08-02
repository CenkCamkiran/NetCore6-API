using Models.DataAccessLayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface IMoviesCacheRepository
	{
		public List<Movie> GetAllMoviesCache(string key);
		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl);
		public Movie GetMovieCommentsByMovieIdCache(string key, string id);
	}
}
