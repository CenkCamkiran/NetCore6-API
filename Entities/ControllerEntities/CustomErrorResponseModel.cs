using Newtonsoft.Json;

namespace Entities.ControllerEntities
{
	public class CustomErrorResponseModel
	{
		[JsonProperty(PropertyName = "errorMessage", Required = Required.AllowNull)]
		public string? ErrorMessage { get; set; }

		[JsonProperty(PropertyName = "errorCode", Required = Required.AllowNull)]
		public string? ErrorCode { get; set; }
	}
}
