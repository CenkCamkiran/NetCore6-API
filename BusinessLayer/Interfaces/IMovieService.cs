using Models.DataAccessLayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IMovieService
	{
		public List<Movie> GetAllMovies();
		public Movie GetMovieCommentsByMovieId(string id);

		public List<Movie> GetAllMoviesCache(string key);
		public void SetAllMoviesCache(string key, string jsonData, TimeSpan ttl);
	}
}
