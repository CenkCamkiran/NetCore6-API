using Newtonsoft.Json;

namespace Models.ControllerModels
{
	public class UserSignupRequest
	{
		public string username { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public Attributes attributes { get; set; }
		public Credentials credentials { get; set; }
	}

	public class Attributes
	{
		public string gender { get; set; }
		public string phoneNumber { get; set; }
		public string country { get; set; }
		public string age { get; set; }

	}

	public class Credentials
	{
		public string password { get; set; }
	}
}
