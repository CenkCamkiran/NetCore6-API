namespace Models.DataAccessLayerModels
{
	public class ControllerRequestResponseLog
	{
		public DateTime RequestDate { get; set; }

		public string? Method { get; set; }

		public string? Protocol { get; set; }

		public string? RequestPath { get; set; }

		public string? RequestHost { get; set; }

		public object? RequestJSONBody { get; set; }

		public DateTime ResponseDate { get; set; }

		public object? ResponseJSONBody { get; set; }

		public object? ResponseHeaders { get; set; }
	}

}
