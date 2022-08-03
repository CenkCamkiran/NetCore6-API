using Models.DataAccessLayerModels;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface IMoviesRepository
	{
		public List<Movie> GetAllMovies();
		public MovieComments GetMovieCommentsByMovieId(string id);
		public List<MovieComments> GetAllMoviesWithComment();
	}
}
