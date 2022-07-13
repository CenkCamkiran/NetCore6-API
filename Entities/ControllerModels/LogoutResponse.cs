using Newtonsoft.Json;

namespace Models.ControllerModels
{
	public class LogoutResponse
	{
		[JsonProperty(PropertyName = "responseMessage")]
		public string responseMessage { get; set; }

		[JsonProperty(PropertyName = "responseCode")]
		public string responseCode { get; set; }
	}
}
