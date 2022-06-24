using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser
{

    public class CreateUserRequestModel
    {
        public long createdTimestamp { get; set; }
        public string username { get; set; }
        public bool enabled { get; set; }

        [JsonIgnore]
        public bool totp { get; set; }

        [JsonIgnore]
        public bool emailVerified { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        [JsonIgnore]
        public List<object> disableableCredentialTypes { get; set; }

        [JsonIgnore]
        public List<object> requiredActions { get; set; }

        [JsonIgnore]
        public int notBefore { get; set; }
        public Attributes attributes { get; set; }

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
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string country { get; set; }
        public string age { get; set; }
    }

    public class Credential
    {
        public string type { get; set; }
        public bool temporary { get; set; }
        public string value { get; set; }

        public static implicit operator List<object>(Credential v)
        {
            throw new NotImplementedException();
        }
    }

}
