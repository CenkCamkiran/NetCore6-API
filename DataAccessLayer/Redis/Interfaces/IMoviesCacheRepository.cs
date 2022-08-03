using Models.DataAccessLayerModels;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface IMoviesCacheRepository
	{
		public List<Movie> GetAllMoviesCache(string key);
		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl);
		public MovieComments GetMovieCommentsByMovieIdCache(string key, string id);
		public bool ClearMoviesCache(string key);
	}
}
