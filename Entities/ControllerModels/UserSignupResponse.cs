using Newtonsoft.Json;

namespace Models.ControllerModels
{
	public class UserSignupResponse //: GeneralResponseModel
	{
		[JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
		public string ResponseMessage { get; set; }

		[JsonProperty(PropertyName = "responseCode", Required = Required.Always)]
		public string ResponseCode { get; set; }
	}
}
