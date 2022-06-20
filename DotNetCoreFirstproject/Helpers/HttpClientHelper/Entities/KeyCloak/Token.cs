using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token
{

    public partial class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("refresh_expires_in")]
        public long RefreshExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("not-before-policy")]
        public long NotBeforePolicy { get; set; }

        [JsonProperty("session_state")]
        public Guid SessionState { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }

    public partial class Token
    {
        public static Token FromJson(string json) => JsonConvert.DeserializeObject<Token>(json, DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Token self) => JsonConvert.SerializeObject(self, DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token.Converter.Settings);
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
