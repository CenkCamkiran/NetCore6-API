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

		public async Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response)
		{
			await repository.InsertControllerRequestResponseLog(request, response);
		}
	}
}
