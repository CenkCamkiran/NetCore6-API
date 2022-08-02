using Microsoft.AspNetCore.Http;

namespace ServiceLayer.Interfaces
{
	public interface ILoggingService
	{
		public Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response);
	}
}
