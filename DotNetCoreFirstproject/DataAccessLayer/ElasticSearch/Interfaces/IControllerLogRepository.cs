namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IControllerLogRepository
	{
		public void InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response);
	}
}
