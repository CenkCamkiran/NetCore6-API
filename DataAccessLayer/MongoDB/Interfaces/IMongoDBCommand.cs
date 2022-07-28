using MongoDB.Bson;
using System.Linq.Expressions;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface IMongoDBCommand<LocalCollectionModel, ForeignCollectionModel>
	{
		public IEnumerable<LocalCollectionModel> SearchDocument(Expression<Func<LocalCollectionModel, bool>> query);
		public string LookupClassicWithUnwind(Expression<Func<LocalCollectionModel, bool>> query, string localField, string foreignField, string resultField, BsonArray pipeline);
		public string LookupClassicWithoutUnwind(Expression<Func<LocalCollectionModel, bool>> query, string localField, string foreignField, string resultField);
		public string AggregationPipeline(Expression<Func<LocalCollectionModel, bool>> query, BsonDocument[] stages);
		public IEnumerable<LocalCollectionModel> LookupLinq(object query);
		public object LookupLinqExample();

		public void UpdateDocument(string id, Expression<Func<LocalCollectionModel, bool>> query);
		public void ReplaceDocument(Expression<Func<LocalCollectionModel, bool>> query, LocalCollectionModel dataModel);

		public void InsertDocument(LocalCollectionModel document);
	}
}
