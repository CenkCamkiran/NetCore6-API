using DataAccessLayer.MongoDB.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccessLayer.MongoDB.Infrastructure
{
	public class MongoDBCommand<CollectionModel> : MongoDBConnection, IMongoDBCommand<CollectionModel> where CollectionModel : class
	{

		private readonly IMongoCollection<CollectionModel> _mongoCollection;

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
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void UpdateDocument(string id, Expression<Func<CollectionModel, bool>> query)
		{
			//Still dont know how to use it
			try
			{
				_mongoCollection.UpdateOne(query, id);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void ReplaceDocument(Expression<Func<CollectionModel, bool>> query, CollectionModel dataModel)
		{

			try
			{
				_mongoCollection.ReplaceOne(query, dataModel);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void InsertDocument(CollectionModel document)
		{

			try
			{
				_mongoCollection.InsertOne(document);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
	}
}
