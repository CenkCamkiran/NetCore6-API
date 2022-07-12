using Newtonsoft.Json;

namespace Models.ControllerModels
{
	public class CustomErrorResponse
	{
		[JsonProperty(PropertyName = "errorMessage", Required = Required.AllowNull)]
		public string? ErrorMessage { get; set; }

		[JsonProperty(PropertyName = "errorCode", Required = Required.AllowNull)]
		public string? ErrorCode { get; set; }
	}
}
