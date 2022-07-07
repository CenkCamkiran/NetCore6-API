using Newtonsoft.Json;

namespace Entities.ControllerEntities
{
    public class UserSignupResponseModel //: GeneralResponseModel
    {
        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "responseCode", Required = Required.Always)]
        public string ResponseCode { get; set; }
    }
}
