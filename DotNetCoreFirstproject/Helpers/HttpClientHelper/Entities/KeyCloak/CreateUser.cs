using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak
{
    public partial class KeycloakCreateUser
    {
        [JsonProperty("createdTimestamp")]
        public long CreatedTimestamp { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("totp")]
        public bool Totp { get; set; }

        [JsonProperty("emailVerified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("disableableCredentialTypes")]
        public object[] DisableableCredentialTypes { get; set; }

        [JsonProperty("requiredActions")]
        public object[] RequiredActions { get; set; }

        [JsonProperty("notBefore")]
        public long NotBefore { get; set; }

        [JsonProperty("access")]
        public Access Access { get; set; }

        [JsonProperty("realmRoles")]
        public string[] RealmRoles { get; set; }
    }

    public partial class Access
    {
        [JsonProperty("manageGroupMembership")]
        public bool ManageGroupMembership { get; set; }

        [JsonProperty("view")]
        public bool View { get; set; }

        [JsonProperty("mapRoles")]
        public bool MapRoles { get; set; }

        [JsonProperty("impersonate")]
        public bool Impersonate { get; set; }

        [JsonProperty("manage")]
        public bool Manage { get; set; }
    }

    public partial class Welcome10
    {
        public static Welcome10 FromJson(string json) => JsonConvert.DeserializeObject<Welcome10>(json, CodeBeautify.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome10 self) => JsonConvert.SerializeObject(self, CodeBeautify.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
