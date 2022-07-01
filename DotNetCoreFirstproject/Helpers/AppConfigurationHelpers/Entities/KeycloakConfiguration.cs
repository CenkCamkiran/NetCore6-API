namespace DotNetCoreFirstproject.Helpers.AppConfigurationHelpers
{
	public partial class AppConfigurationHelper
    {

        protected string? Host { get; set; }
        protected string? AdminUsername { get; set; }
        protected string? AdminPassword { get; set; }
        protected string? AdminRealmName { get; set; }
        protected string? AdminClientID { get; set; }
        protected string? AdminClientSecret { get; set; }
        protected string? UserUsername { get; set; }
        protected string? UserPassword { get; set; }
        protected string? UserRealmName { get; set; }
        protected string? UserClientID { get; set; }
        protected string? UserClientSecret { get; set; }
        protected string? TokenRoute { get; set; }
        protected string? UsersRoute { get; set; }
        protected string? SessionRoute { get; set; }
        protected string? AdminID { get; set; }
    }
}
