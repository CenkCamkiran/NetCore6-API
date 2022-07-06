using Newtonsoft.Json;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Entities
{
	public class ControllerRequestResponseModel
	{
		[JsonProperty(PropertyName = "RequestInfo")]
		public Request? RequestInfo { get; set; }

		[JsonProperty(PropertyName = "ResponseInfo")]
		public Response? ResponseInfo { get; set; }	
	}

	public class Request
	{

		[JsonProperty(PropertyName = "RequestJSONBody")]
		public object? RequestJSONBody { get; set; }

		[JsonProperty(PropertyName = "RequestDate")]
		public DateTime RequestDate { get; set; }

		[JsonProperty(PropertyName = "method")]
		public string? Method { get; set; }

		[JsonProperty(PropertyName = "protocol")]
		public string? Protocol { get; set; }

		[JsonProperty(PropertyName = "requestPath")]
		public string? RequestPath { get; set; }

		[JsonProperty(PropertyName = "requestHost")]
		public string? RequestHost { get; set; }
	}

	public class Response
	{

		[JsonProperty(PropertyName = "ResponseJSONBody")]
		public object? ResponseJSONBody { get; set; }

		[JsonProperty(PropertyName = "ResponseHeaders")]
		public object? ResponseHeaders { get; set; }

		[JsonProperty(PropertyName = "ResponseDate")]
		public DateTime ResponseDate { get; set; }
	}
}
