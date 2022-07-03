namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IElasticSearchCommand
	{
		public void InsertDocument();//
		public void UpdateDocument();
		public void DeleteDocument();

	}
}
