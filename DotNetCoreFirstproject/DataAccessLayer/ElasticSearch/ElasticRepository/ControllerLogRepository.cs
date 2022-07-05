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

			try
			{
				using (StreamReader requestStream = new StreamReader(request.Body), responseStream = new StreamReader(response.Body))
				{
				    var JSONRequestBody = await requestStream.ReadToEndAsync();
					var JSONResponseBody = await responseStream.ReadToEndAsync();

					JObject? jsonRequestObject = string.IsNullOrEmpty(JSONRequestBody) == null ? JObject.Parse(JSONRequestBody) : null;
					JObject? jsonResponseObject = string.IsNullOrEmpty(JSONResponseBody) == null ? JObject.Parse(JSONResponseBody) : null;

					ControllerRequestResponseModel model = new ControllerRequestResponseModel()
					{
						RequestPath = request.Path,
						RequestHost = request.Host.ToString(),
						RequestInfo = new Request()
						{
							RequestDate = DateTime.Now,
							RequestHeaders = request.Headers,
							RequestJSONBody = jsonRequestObject
						},
						ResponseInfo = new Response()
						{
							ResponseDate = DateTime.Now,
							ResponseHeaders = response.Headers,
							ResponseJSONBody = jsonResponseObject
						}
					};

					elasticCommand.InsertDocument(model);

				}

			}
			finally
			{

			}

		}
	}
}
