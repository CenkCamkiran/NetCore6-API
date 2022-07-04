using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Elastic;
using DotNetCoreFirstproject.ServiceLayer.Interfaces;

namespace DotNetCoreFirstproject.ServiceLayer
{
	public class LoggingService : ILoggingService
	{
		private ControllerLogRepository repository;

		public LoggingService()
		{
			repository = new ControllerLogRepository();
		}

		public void InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response)
		{
			repository.InsertControllerRequestResponseLog(request, response);
		}
	}
}
