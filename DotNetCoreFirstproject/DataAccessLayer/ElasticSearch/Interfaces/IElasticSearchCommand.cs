using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Entities;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IElasticSearchCommand
	{
		public void InsertDocument(ControllerRequestResponseModel document);
		public void UpdateDocument(object document);
		public void DeleteDocument(object document);
		public void SearchDocument(object document);
	}
}
