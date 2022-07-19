namespace Configurations
{
	public partial class AppConfiguration
	{
		protected string? MongoDBHost { get; set; }
		protected string? MongoDBConnectionString { get; set; }
		protected string? MongoDBAdminUsername { get; set; }
		protected string? MongoDBAdminPassword { get; set; }
		protected string? DefaultDatabaseName { get; set; }
	}
}
