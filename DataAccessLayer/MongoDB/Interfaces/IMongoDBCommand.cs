using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
