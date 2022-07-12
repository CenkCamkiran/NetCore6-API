namespace Models.ControllerModels
{
	[Serializable]
	public class APIHealthResponse
	{
		public string HealthStatus { get; set; }
		public string HealthStatusDescription { get; set; }
	}
}
