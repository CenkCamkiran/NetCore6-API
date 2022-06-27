using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Helpers.Entities
{
    [Serializable]
    public class CustomErrorResponseModel
    {
        [JsonProperty(PropertyName = "ErrorMessage", Required = Required.AllowNull)]
        public string? ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "ErrorCode", Required = Required.AllowNull)]
        public string? ErrorCode { get; set; }

        [JsonIgnore]
        public string KeycloakToken { get; set; }
    }
}
