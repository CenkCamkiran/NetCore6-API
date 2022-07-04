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

		public void InsertControllerRequestResponseLog(HttpRequest request, HttpResponse response)
		{

			using (StreamReader requestStream = new StreamReader(request.Body), responseStream = new StreamReader(response.Body))
			{
				var JSONRequestBody = requestStream.ReadToEnd();
				var JSONResponseBody = responseStream.ReadToEnd();

				JObject? jsonRequestObject = JObject.Parse(JSONRequestBody.Result);
				JObject? jsonResponseObject = JObject.Parse(JSONResponseBody.Result);

				ControllerRequestResponseModel model = new ControllerRequestResponseModel()
				{
					RequestPath = request.Path,
					RequestInfo = new Request()
					{
						RequestDate = DateTime.ParseExact(request.Headers.Date.ToString(), "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture),
						RequestHeaders = request.Headers,
						RequestJSONBody = jsonRequestObject
					},
					ResponseInfo = new Response()
					{
						ResponseDate = DateTime.ParseExact(response.Headers.Date.ToString(), "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture),
						ResponseHeaders = response.Headers,
						ResponseJSONBody = jsonResponseObject
					}
				};

				elasticCommand.InsertDocument(model);

			}

		}
	}
}
