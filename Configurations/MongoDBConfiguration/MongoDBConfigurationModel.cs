using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
