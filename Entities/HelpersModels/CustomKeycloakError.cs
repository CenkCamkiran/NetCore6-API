namespace Models.HelpersModels
{
	[Serializable]
	public class CustomKeycloakError
	{
		public string? ErrorMessage { get; set; }
		public string? ErrorCode { get; set; }
		public TokenResponse? KeycloakToken { get; set; }
	}
}
