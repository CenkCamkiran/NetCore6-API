using Microsoft.AspNetCore.Http;

namespace DataAccessLayer.ElasticSearch.Interfaces
{
	public interface IControllerLogRepository
	{
		public Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response);
	}
}
