namespace DotNetCoreFirstproject.Configuration
{
    public class ProjectSettings
    {
        public const string RootOption = "ExternalTools";

        public static ExternalTools ExternalTools { get; set; } = new ExternalTools();


    }
}
