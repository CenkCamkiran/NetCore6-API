namespace DotNetCoreFirstproject.Controllers.Entities
{
	[Serializable]
	public class APIHealthResponseModel
	{
		public string HealthStatus { get; set; }
		public string HealthStatusDescription { get; set; }	
	}
}
