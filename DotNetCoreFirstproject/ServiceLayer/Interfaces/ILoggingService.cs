namespace DotNetCoreFirstproject.ServiceLayer.Interfaces
{
	public interface ILoggingService
	{
		public void InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response);
	}
}
