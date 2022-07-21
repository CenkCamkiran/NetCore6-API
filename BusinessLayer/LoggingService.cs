using BusinessLayer.Interfaces;
using DataAccessLayer.ElasticSearch.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer
{
	public class LoggingService : ILoggingService
	{
		private IControllerLogRepository _controllerLogRepository;

		public LoggingService(IControllerLogRepository controllerLogRepository)
		{
			_controllerLogRepository = controllerLogRepository;
		}

		public async Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response)
		{
			await _controllerLogRepository.InsertControllerRequestResponseLog(request, response);
		}
	}
}
