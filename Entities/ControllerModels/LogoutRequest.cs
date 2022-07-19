namespace Models.ControllerModels
{
	public class LogoutRequest
	{
		public string accessToken { get; set; }
		public string refreshToken { get; set; }
	}
}
