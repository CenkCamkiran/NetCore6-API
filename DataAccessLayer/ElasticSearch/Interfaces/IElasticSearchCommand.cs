using Entities.DataAccessLayerEntities;

namespace DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IElasticSearchCommand
	{
		public void IndexData(ControllerRequestResponseModel? document);
		public void UpdateDocument(object document);
		public void DeleteDocument(object document);
		public void SearchDocument(object document);
	}
}
