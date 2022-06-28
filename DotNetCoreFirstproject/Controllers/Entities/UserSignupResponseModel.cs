using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    public class UserSignupResponseModel //: GeneralResponseModel
    {
        [JsonProperty(PropertyName = "ResponseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "ResponseCode")]
        public string ResponseCode { get; set; }
    }
}
