using Newtonsoft.Json;

namespace Entities.ControllerEntities
{
    public class UserLoginResponseModel
    {
        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string access_token { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public int expires_in { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public int refresh_expires_in { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string refresh_token { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string token_type { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public int NotBeforePolicy { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string session_state { get; set; }

        [JsonProperty(PropertyName = "responseMessage", Required = Required.Always)]
        public string scope { get; set; }
    }
}
