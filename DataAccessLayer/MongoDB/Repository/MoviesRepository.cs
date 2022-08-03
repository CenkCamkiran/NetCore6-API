using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

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

			return mongoCommand.SearchLimitedDocument(_ => true, 25).ToList();
		}

		public List<MovieComments> GetAllMoviesWithComment()
		{
			MongoDBCommand<MovieComments, object> mongoCommand = new MongoDBCommand<MovieComments, object>(MFLIX_DB_NAME, MFLIX_COLLECTION_NAME, _mongoClient);

			var stages = new BsonDocument[]
			{
	             new BsonDocument("$lookup",
	             new BsonDocument
	             	{
	             		{ "from", "comments" },
	             		{ "localField", "_id" },
	             		{ "foreignField", "movie_id" },
	             		{ "as", "comments" }
	             	}),
	             new BsonDocument("$project",
	             new BsonDocument("comments",
	             new BsonDocument("movie_id", 0))),
	             new BsonDocument("$limit", 25)
			};

			string jsonData = mongoCommand.AggregationPipeline(_ => true, stages);
			List<MovieComments>? movieCommentList = BsonSerializer.Deserialize<List<MovieComments>>(jsonData);

			return movieCommentList;
		}

		public MovieComments GetMovieCommentsByMovieId(string id)
		{
			MongoDBCommand<Movie, object> mongoCommand = new MongoDBCommand<Movie, object>(MFLIX_DB_NAME, MFLIX_COLLECTION_NAME, _mongoClient);

			var stages = new BsonDocument[]
			{
					new BsonDocument("$match",
	new BsonDocument("_id",
	new ObjectId(id))),
	new BsonDocument("$lookup",
	new BsonDocument
		{
			{ "from", "comments" },
			{ "localField", "_id" },
			{ "foreignField", "movie_id" },
			{ "as", "comments" }
		}),
	new BsonDocument("$project",
	new BsonDocument("comments",
	new BsonDocument("movie_id", 0)))
			};

			string? jsonData = mongoCommand.AggregationPipeline(_ => true, stages);

			List<MovieComments> movieCommentslist = BsonSerializer.Deserialize<List<MovieComments>>(jsonData);
			MovieComments? movieComments = null;

			if (movieCommentslist != null)
			{
				movieComments = movieCommentslist.SingleOrDefault();
			}

			return movieComments;
		}
	}
}
