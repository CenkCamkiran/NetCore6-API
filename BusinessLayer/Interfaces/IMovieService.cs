using Models.DataAccessLayerModels;

namespace ServiceLayer.Interfaces
{
	public interface IMovieService
	{
		public List<Movie> GetAllMovies();
		public MovieComments GetMovieCommentsByMovieId(string id);
		public MovieComments GetMovieCommentsByMovieIdCache(string key, string id);

		public List<Movie> GetAllMoviesCache(string key);
		public List<MovieComments> GetAllMoviesWithComment();
		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl);
		public bool ClearMoviesCache(string key);

	}
}
