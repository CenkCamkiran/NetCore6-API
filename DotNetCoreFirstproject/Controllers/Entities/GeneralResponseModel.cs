using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    [Serializable]
    public class GeneralResponseModel
    {
        [JsonProperty(PropertyName = "ResponseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "ResponseCode")]
        public string ResponseCode { get; set; }
    }
}
