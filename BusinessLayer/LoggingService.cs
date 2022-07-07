using BusinessLayer.Interfaces;
using DataAccessLayer.ElasticSearch.ElasticRepository;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer
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
