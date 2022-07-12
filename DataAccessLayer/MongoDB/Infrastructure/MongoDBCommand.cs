using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccessLayer.MongoDB.Infrastructure
{
	public class MongoDBCommand<CollectionModel> : MongoDBConnection, IMongoDBCommand<CollectionModel> where CollectionModel : class
	{

		IMongoCollection<CollectionModel> _mongoCollection;

		public MongoDBCommand(string DatabaseName, string CollectionName) : base(DatabaseName, CollectionName)
		{
			//try-catch?
			IMongoDatabase? MongoDatabase = MongoClient.GetDatabase(DatabaseName);

			_mongoCollection = MongoDatabase.GetCollection<CollectionModel>(CollectionName);
		}

		public IEnumerable<CollectionModel> SearchDocument(Expression<Func<CollectionModel, bool>> query)
		{
			//return _mongoCollection.AsQueryable().Where(query).ToList();

			try
			{
				return _mongoCollection.Find(query).ToList();
			}
			finally
			{
				//
			}
		}

		public void UpdateDocument(string id, Expression<Func<CollectionModel, bool>> query)
		{

			//try
			//{
			//	return _mongoCollection.UpdateOne(query);
			//}
			//finally
			//{
			//	//
			//}
		}
	}
}
