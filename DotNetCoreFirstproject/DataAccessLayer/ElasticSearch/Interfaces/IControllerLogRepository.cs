namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IControllerLogRepository
	{
		public void InsertControllerRequestLog();
		public void InsertControllerResponseLog();
	}
}
