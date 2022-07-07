namespace DotNetCoreFirstproject.Configuration
{
    public class ApplicationSettings
    {
        public const string RootOption = "ExternalTools";

        public static ExternalTools ExternalTools { get; set; } = new ExternalTools();


    }
}
