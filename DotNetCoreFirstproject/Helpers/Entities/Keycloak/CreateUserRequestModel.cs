using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser
{

    public class CreateUserRequestModel
    {

        [JsonProperty(PropertyName = "createdTimestamp", Required = Required.Always)]
        public long createdTimestamp { get; set; }

        [JsonProperty(PropertyName = "username", Required = Required.Always)]
        public string username { get; set; }

        [JsonProperty(PropertyName = "enabled", Required = Required.Always)]
        public bool enabled { get; set; }

        [JsonIgnore]
        public bool totp { get; set; }

        [JsonIgnore]
        public bool emailVerified { get; set; }

        [JsonProperty(PropertyName = "firstName", Required = Required.Always)]
        public string firstName { get; set; }

        [JsonProperty(PropertyName = "lastName", Required = Required.Always)]
        public string lastName { get; set; }

        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string email { get; set; }

        [JsonIgnore]
        public List<object> disableableCredentialTypes { get; set; }

        [JsonIgnore]
        public List<object> requiredActions { get; set; }

        [JsonIgnore]
        public int notBefore { get; set; }

        [JsonProperty(PropertyName = "attributes", Required = Required.Always)]
        public Attributes attributes { get; set; }

        [JsonProperty(PropertyName = "credentials", Required = Required.Always)]
        public List<Credential> credentials { get; set; }

        [JsonIgnore]
        public Access access { get; set; }

        [JsonIgnore]
        public List<string> realmRoles { get; set; }
    }

    public class Access
    {
        [JsonIgnore]
        public bool manageGroupMembership { get; set; }

        [JsonIgnore]
        public bool view { get; set; }

        [JsonIgnore]
        public bool mapRoles { get; set; }

        [JsonIgnore]
        public bool impersonate { get; set; }

        [JsonIgnore]
        public bool manage { get; set; }
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

    public class Credential
    {

        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string type { get; set; }

        [JsonProperty(PropertyName = "temporary", Required = Required.Always)]
        public bool temporary { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public string value { get; set; }

        public static implicit operator List<object>(Credential v)
        {
            throw new NotImplementedException();
        }
    }

}
