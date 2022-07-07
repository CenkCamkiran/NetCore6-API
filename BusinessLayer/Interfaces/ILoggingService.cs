using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Interfaces
{
	public interface ILoggingService
	{
		public Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response);
	}
}
