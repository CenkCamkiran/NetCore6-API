using DataAccessLayer.ElasticSearch.Infrastructure;
using DataAccessLayer.ElasticSearch.Interfaces;
using Microsoft.AspNetCore.Http;
using Models.DataAccessLayerModels;
using Newtonsoft.Json.Linq;

namespace DataAccessLayer.ElasticSearch.Repository
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

				JToken? jsonRequestObject = string.IsNullOrEmpty(JSONRequestBody) ? null : JToken.Parse(JSONRequestBody);
				JToken? jsonResponseObject = string.IsNullOrEmpty(JSONResponseBody) ? null : JToken.Parse(JSONResponseBody);

				ControllerRequestResponseLog model = new ControllerRequestResponseLog()
				{
					RequestDate = DateTime.Now,
					RequestJSONBody = jsonRequestObject?.ToString(),
					Method = request.Method,
					Protocol = request.Protocol,
					RequestHost = request.Host.ToString(),
					RequestPath = request.Path.ToString(),
					ResponseDate = DateTime.Now,
					ResponseJSONBody = jsonResponseObject?.ToString()
				};

				elasticCommand.IndexData(model);

			}
			finally
			{
				//
			}

		}
	}
}
