using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser
{

    public partial class CreateUser
    {
        [JsonProperty("createdTimestamp")]
        public long CreatedTimestamp { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("totp")]
        [JsonIgnore]
        public bool Totp { get; set; }

        [JsonProperty("emailVerified")]
        [JsonIgnore]
        public bool EmailVerified { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("disableableCredentialTypes")]
        [JsonIgnore]
        public object[] DisableableCredentialTypes { get; set; }

        [JsonProperty("requiredActions")]
        [JsonIgnore]
        public object[] RequiredActions { get; set; }

        [JsonProperty("notBefore")]
        [JsonIgnore]
        public long NotBefore { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("credentials")]
        public Credential[] Credentials { get; set; }

        [JsonProperty("access")]
        [JsonIgnore]
        public Access Access { get; set; }

        [JsonProperty("realmRoles")]
        [JsonIgnore]
        public string[] RealmRoles { get; set; }
    }

    public partial class Access
    {
        [JsonProperty("manageGroupMembership")]
        [JsonIgnore]
        public bool ManageGroupMembership { get; set; }

        [JsonProperty("view")]
        [JsonIgnore]
        public bool View { get; set; }

        [JsonProperty("mapRoles")]
        [JsonIgnore]
        public bool MapRoles { get; set; }

        [JsonProperty("impersonate")]
        [JsonIgnore]
        public bool Impersonate { get; set; }

        [JsonProperty("manage")]
        [JsonIgnore]
        public bool Manage { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("age")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Age { get; set; }
    }

    public partial class Credential
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("temporary")]
        public bool Temporary { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class CreateUser
    {
        public static CreateUser FromJson(string json) => JsonConvert.DeserializeObject<CreateUser>(json, DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CreateUser self) => JsonConvert.SerializeObject(self, DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser.Converter.Settings);
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

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
