using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Entities;
using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Infrastructure;
using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Elastic
{
	public class ControllerLogRepository : IControllerLogRepository
	{
		private ElasticSearchCommand elasticCommand;
		 
		public ControllerLogRepository()
		{
			elasticCommand = new ElasticSearchCommand();	
		}

		public void InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response)
		{

			ControllerRequestResponseModel model = new ControllerRequestResponseModel();

			elasticCommand.InsertDocument(model);
		}
	}
}
