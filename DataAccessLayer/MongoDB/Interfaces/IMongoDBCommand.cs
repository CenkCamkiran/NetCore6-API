using System.Linq.Expressions;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface IMongoDBCommand<CollectionModel>
	{
		public IEnumerable<CollectionModel> SearchDocument(Expression<Func<CollectionModel, bool>> query);

		public void UpdateDocument(string id, Expression<Func<CollectionModel, bool>> query);
		public void ReplaceDocument(Expression<Func<CollectionModel, bool>> query, CollectionModel dataModel);

		public void InsertDocument(CollectionModel document);
	}
}
