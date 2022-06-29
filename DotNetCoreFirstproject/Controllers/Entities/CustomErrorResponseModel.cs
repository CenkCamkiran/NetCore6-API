using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    public class CustomErrorResponseModel
    {
        [JsonProperty(PropertyName = "errorMessage", Required = Required.AllowNull)]
        public string? ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "errorCode", Required = Required.AllowNull)]
        public string? ErrorCode { get; set; }
    }
}
