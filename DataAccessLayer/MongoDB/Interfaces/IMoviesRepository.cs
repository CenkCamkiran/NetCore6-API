using Models.DataAccessLayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface IMoviesRepository
	{
		public List<Movie> GetAllMovies();
		public Movie GetMovieCommentsByMovieId(string id);
	}
}
