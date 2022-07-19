using Newtonsoft.Json;


namespace Models.HelpersModels
{
	public class RealmManagement
	{
		[JsonProperty("roles")]
		public List<string> roles { get; set; }
	}

	public class ResourceAccess
	{
		[JsonProperty("realm-management")]
		public RealmManagement RealmManagement { get; set; }
	}

	public class DecodedToken
	{
		[JsonProperty("exp")]
		public int exp { get; set; }

		[JsonProperty("iat")]
		public int iat { get; set; }

		[JsonProperty("jti")]
		public string jti { get; set; }

		[JsonProperty("iss")]
		public string iss { get; set; }

		[JsonProperty("aud")]
		public string aud { get; set; }

		[JsonProperty("sub")]
		public string sub { get; set; }

		[JsonProperty("typ")]
		public string typ { get; set; }

		[JsonProperty("azp")]
		public string azp { get; set; }

		[JsonProperty("session_state")]
		public string session_state { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("given_name")]
		public string given_name { get; set; }

		[JsonProperty("family_name")]
		public string family_name { get; set; }

		[JsonProperty("preferred_username")]
		public string preferred_username { get; set; }

		[JsonProperty("email")]
		public string email { get; set; }

		[JsonProperty("email_verified")]
		public bool email_verified { get; set; }

		[JsonProperty("acr")]
		public string acr { get; set; }

		[JsonProperty("allowed-origins")]
		public List<string> AllowedOrigins { get; set; }

		[JsonProperty("resource_access")]
		public ResourceAccess resource_access { get; set; }

		[JsonProperty("scope")]
		public string scope { get; set; }

		[JsonProperty("sid")]
		public string sid { get; set; }

		[JsonProperty("client_id")]
		public string client_id { get; set; }

		[JsonProperty("username")]
		public string username { get; set; }

		[JsonProperty("active")]
		public bool active { get; set; }
	}


}
