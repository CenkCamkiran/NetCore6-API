using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    public class UserSignupRequestModel
    {
        [JsonProperty(PropertyName = "username", Required = Required.Always)]
        public string username { get; set; }

        [JsonProperty(PropertyName = "firstName", Required = Required.Default)]
        public string firstName { get; set; }

        [JsonProperty(PropertyName = "lastName", Required = Required.Always)]
        public string lastName { get; set; }

        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string email { get; set; }

        [JsonProperty(PropertyName = "attributes", Required = Required.Always)]
        public Attributes attributes { get; set; }

        [JsonProperty(PropertyName = "credentials", Required = Required.Always)]
        public Credentials credentials { get; set; }
    }

    public class Attributes
    {
        [JsonProperty(PropertyName = "gender", Required = Required.Always)]
        public string gender { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", Required = Required.Always)]
        public string phoneNumber { get; set; }

        [JsonProperty(PropertyName = "country", Required = Required.Always)]
        public string country { get; set; }

        [JsonProperty(PropertyName = "age", Required = Required.Always)]
        public string age { get; set; }

    }

    public class Credentials
    {
        [JsonProperty(PropertyName = "password", Required = Required.Always)]
        public string password { get; set; }
    }
}
