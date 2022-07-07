using Newtonsoft.Json;

namespace Entities.ControllerEntities
{
    public class UserLoginResponseModel
    {
        [JsonProperty(PropertyName = "accesToken", Required = Required.Always)]
        public string access_token { get; set; }

        [JsonProperty(PropertyName = "expiresIn", Required = Required.Always)]
        public int expires_in { get; set; }


        [JsonProperty(PropertyName = "refreshToken", Required = Required.Always)]
        public string refresh_token { get; set; }

        [JsonProperty(PropertyName = "refreshExpiresIn", Required = Required.Always)]
        public int refresh_expires_in { get; set; }

        [JsonProperty(PropertyName = "tokenType", Required = Required.Always)]
        public string token_type { get; set; }

        [JsonProperty(PropertyName = "sessionState", Required = Required.Always)]
        public string session_state { get; set; }
    }
}
