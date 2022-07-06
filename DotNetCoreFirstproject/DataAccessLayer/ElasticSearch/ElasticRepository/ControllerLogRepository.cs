using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Entities;
using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Infrastructure;
using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Elastic
{
	public class ControllerLogRepository : IControllerLogRepository
	{
		private ElasticSearchCommand elasticCommand;
		 
		public ControllerLogRepository()
		{
			elasticCommand = new ElasticSearchCommand();
		}

		public async Task InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response)
		{
			//That way any code later in the request lifecycle will find the request.Body in a state just like it hasn't been read yet.
			request.Body.Position = 0;
			response.Body.Position = 0;

			try
			{

				//I did not close stream on purpose.
				StreamReader requestStream = new StreamReader(request.Body);
				StreamReader responseStream = new StreamReader(response.Body);

				var JSONRequestBody = await requestStream.ReadToEndAsync();
				var JSONResponseBody = await responseStream.ReadToEndAsync();

				JObject? jsonRequestObject = string.IsNullOrEmpty(JSONRequestBody) == null ? JObject.Parse(JSONRequestBody) : null;
				JObject? jsonResponseObject = string.IsNullOrEmpty(JSONResponseBody) == null ? JObject.Parse(JSONResponseBody) : null;

				ControllerRequestResponseModel model = new ControllerRequestResponseModel()
				{
					RequestInfo = new Request()
					{
						RequestDate = DateTime.Now,
						RequestJSONBody = JSONRequestBody,
						Method = request.Method,
						Protocol = request.Protocol,
						RequestHost = request.Host.ToString(),
						RequestPath = request.Path.ToString()
					},
					ResponseInfo = new Response()
					{
						ResponseDate = DateTime.Now,
						ResponseJSONBody = JSONResponseBody
					}
				};

				elasticCommand.IndexData(model);

			}
			finally
			{

			}

		}
	}
}
