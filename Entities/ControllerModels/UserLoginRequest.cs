namespace Models.ControllerModels
{
	public class UserLoginRequest
	{
		public string username { get; set; }

		public string password { get; set; }

		public string hash { get; set; }
	}
}
