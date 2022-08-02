using DataAccessLayer.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using DataAccessLayer.MongoDB.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataAccessLayerModels;

namespace DataAccessLayer.MongoDB.Repository
{
	public class MoviesRepository : IMoviesRepository
	{
		private const string MFLIX_DB_NAME = "mflix";
		private const string MFLIX_COLLECTION_NAME = "movies";

		private readonly IMongoClient _mongoClient;

		public MoviesRepository(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public List<Movie> GetAllMovies()
		{
			MongoDBCommand<Movie, object> mongoCommand = new MongoDBCommand<Movie, object>(MFLIX_DB_NAME, MFLIX_COLLECTION_NAME, _mongoClient);

			IEnumerable<Movie> movieList = mongoCommand.SearchDocument(_ => true);

			return mongoCommand.SearchDocument(_ => true).ToList();
		}

		public Movie GetMovieCommentsByMovieId(string id)
		{
			MongoDBCommand<Movie, object> mongoCommand = new MongoDBCommand<Movie, object>(MFLIX_DB_NAME, MFLIX_COLLECTION_NAME, _mongoClient);

			Movie movie = mongoCommand.SearchDocument(movie => movie._id == id);
		}
	}
}
