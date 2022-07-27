using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccessLayer.MongoDB.Infrastructure
{
	public class MongoDBCommand<LocalCollectionModel, ForeignCollectionModel> : IMongoDBCommand<LocalCollectionModel, ForeignCollectionModel>
	{

		private readonly IMongoCollection<LocalCollectionModel> _mongoCollectionLocal;
		private readonly IMongoCollection<ForeignCollectionModel> _mongoCollectionForeign;

		public MongoDBCommand(string DatabaseName, string CollectionName, IMongoClient _mongoClient)
		{
			//try-catch?
			IMongoDatabase? MongoDatabase = _mongoClient.GetDatabase(DatabaseName);

			_mongoCollectionLocal = MongoDatabase.GetCollection<LocalCollectionModel>(CollectionName);
		}

		public MongoDBCommand(string DatabaseName, string LocalCollection, string ForeignCollection, IMongoClient _mongoClient)
		{
			//try-catch?
			IMongoDatabase? MongoDatabase = _mongoClient.GetDatabase(DatabaseName);

			_mongoCollectionLocal = MongoDatabase.GetCollection<LocalCollectionModel>(LocalCollection);
			_mongoCollectionForeign = MongoDatabase.GetCollection<ForeignCollectionModel>(ForeignCollection);
		}

		public IEnumerable<LocalCollectionModel> SearchDocument(Expression<Func<LocalCollectionModel, bool>> query)
		{
			//return _mongoCollection.AsQueryable().Where(query).ToList();

			try
			{
				return _mongoCollectionLocal.Find(query).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public string AggregationPipeline(Expression<Func<LocalCollectionModel, bool>> query, IEnumerable<BsonDocument> pipeline)
		{
			try
			{
				var pipelineDefinition = PipelineDefinition<BsonArray, BsonDocument>.Create(pipeline);

				//return _mongoCollectionLocal.Aggregate(pipelineDefinition)  //AppendStage<BsonArray>(pipelineDefinition)

				return null;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public string LookupClassicWithUnwind(Expression<Func<LocalCollectionModel, bool>> query, string localField, string foreignField, string resultField, BsonArray pipeline)
		{

			//var cenk = new BsonDocument();
			try
			{
				return null;
				//return _mongoCollectionLocal.Aggregate().Match(query).Unwind(localField).Lookup(localField: localField, foreignCollectionName: _mongoCollectionForeign.CollectionNamespace.CollectionName, foreignField: foreignField, @as: resultField).AppendStage();
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public string LookupClassicWithoutUnwind(Expression<Func<LocalCollectionModel, bool>> query, string localField, string foreignField, string resultField)
		{
			//return _mongoCollection.AsQueryable().Where(query).ToList();

			return null;
			//try
			//{
			//	return _mongoCollectionLocal.Aggregate().Unwind  Lookup(localField: localField, foreignCollectionName: _mongoCollectionForeign.CollectionNamespace.CollectionName, foreignField: foreignField, @as: "Result").ToEnumerable();
			//}
			//catch (Exception ex)
			//{
			//	throw new Exception();
			//}
		}

		public IEnumerable<LocalCollectionModel> LookupLinq(object query)
		{
			//return _mongoCollection.AsQueryable().Where(query).ToList();

			return null;

		}

		public object LookupLinqExample()
		{
			//return _mongoCollection.AsQueryable().Where(query).ToList();

			return null;

		}

		public void UpdateDocument(string id, Expression<Func<LocalCollectionModel, bool>> query)
		{
			//Still dont know how to use it
			try
			{
				_mongoCollectionLocal.UpdateOne(query, id);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void ReplaceDocument(Expression<Func<LocalCollectionModel, bool>> query, LocalCollectionModel dataModel)
		{

			try
			{
				_mongoCollectionLocal.ReplaceOne(query, dataModel);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public void InsertDocument(LocalCollectionModel document)
		{

			try
			{
				_mongoCollectionLocal.InsertOne(document);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
	}
}
