namespace DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IElasticSearchCommand
	{
		public void IndexData(dynamic document);
		public void UpdateDocument(object document);
		public void DeleteDocument(object document);
		public void SearchDocument(object document);
	}
}
