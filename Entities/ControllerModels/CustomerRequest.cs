namespace Models.ControllerModels
{
	public class CustomerRequest
	{
		public string username { get; set; }

		public string fullname { get; set; }

		public string address { get; set; }

		public string email { get; set; }

		public bool active { get; set; }

		public int[] accounts { get; set; }

		public Dictionary<string, TierAndDetail>? tierAndDetails { get; set; }
	}

	public partial class TierAndDetail
	{

		public string tier { get; set; }

		public string id { get; set; }

		public bool active { get; set; }

		public string[] benefits { get; set; }
	}
}
