namespace Configurations
{
	public class ApplicationSettingsModel
	{
		public const string RootOption = "ExternalTools";

		public static ExternalTools ExternalTools { get; set; } = new ExternalTools();


	}
}
