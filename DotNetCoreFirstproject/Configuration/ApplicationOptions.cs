using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace DotNetCoreFirstproject.Configuration
{

    public partial class ExternalTools
    {
        [JsonProperty("Keycloak")]
        public Keycloak Keycloak { get; set; }

        [JsonProperty("ElasticSearch")]
        public ElasticSearch ElasticSearch { get; set; }
    }

    public partial class ElasticSearch
    {
        [JsonProperty("Host")]
        public Uri Host { get; set; }

        [JsonProperty("Admin")]
        public Admin Admin { get; set; }
    }

    public partial class Admin
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }

    public partial class Keycloak
    {
        [JsonProperty("Host")]
        public Uri Host { get; set; }

        [JsonProperty("Admin")]
        public Admin Admin { get; set; }

        [JsonProperty("Realms")]
        public Realms Realms { get; set; }

        [JsonProperty("Routes")]
        public Routes Routes { get; set; }
    }

    public partial class Realms
    {
        [JsonProperty("UserRealm")]
        public Realm UserRealm { get; set; }

        [JsonProperty("AdminRealm")]
        public Realm AdminRealm { get; set; }
    }

    public partial class Realm
    {
        [JsonProperty("RealmName")]
        public string RealmName { get; set; }

        [JsonProperty("ClientID")]
        public string ClientId { get; set; }

        [JsonProperty("ClientSecret")]
        public string ClientSecret { get; set; }
    }

    public partial class Routes
    {
        [JsonProperty("TokenRoute")]
        public string TokenRoute { get; set; }

        [JsonProperty("UsersRoute")]
        public string UsersRoute { get; set; }
    }

}
