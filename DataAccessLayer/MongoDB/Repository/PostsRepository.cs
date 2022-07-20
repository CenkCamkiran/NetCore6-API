using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using MongoDB.Driver;

namespace DataAccessLayer.MongoDB.Repository
{
	public class PostsRepository : IPostsRepository
	{

		private const string ANALYTICS_DB_NAME = "analytics";
		private const string ANALYTICS_COLLECTION_NAME = "posts";

		private readonly IMongoClient _mongoClient;

		public PostsRepository(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts()
		{
			MongoDBCommand<Models.DataAccessLayerModels.Posts> mongoDBCommand = new MongoDBCommand<Models.DataAccessLayerModels.Posts>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.SearchDocument(_ => true);
		}

	}
}
