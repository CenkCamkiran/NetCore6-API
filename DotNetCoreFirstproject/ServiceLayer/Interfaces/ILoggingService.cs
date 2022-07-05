namespace DotNetCoreFirstproject.ServiceLayer.Interfaces
{
	public interface ILoggingService
	{
		public Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response);
	}
}
