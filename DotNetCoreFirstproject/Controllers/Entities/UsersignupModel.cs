using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    public class UsersignupModel
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("email")]
        public int email { get; set; }

        [JsonProperty("attributes")]
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("age")]
        public string age { get; set; }

    }
}
