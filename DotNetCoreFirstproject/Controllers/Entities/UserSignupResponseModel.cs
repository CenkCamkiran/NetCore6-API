using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    public class UserSignupResponseModel //: GeneralResponseModel
    {
        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "responseCode", Required = Required.Always)]
        public string ResponseCode { get; set; }
    }
}
