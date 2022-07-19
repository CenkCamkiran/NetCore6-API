using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.ControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Repository
{
	public class PostsRepository : IPostsRepository
	{

		private const string ANALYTICS_DB_NAME = "analytics";
		private const string ANALYTICS_COLLECTION_NAME = "posts";

		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts()
		{
			MongoDBCommand<Models.DataAccessLayerModels.Posts> mongoDBCommand = new MongoDBCommand<Models.DataAccessLayerModels.Posts>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME);

			return mongoDBCommand.SearchDocument(_ => true);
		}

	}
}
