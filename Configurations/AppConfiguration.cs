namespace Configurations
{

	public partial class AppConfiguration
	{

		public Dictionary<string, string> GetKeycloakConfig()
		{

			KeycloakHost = ApplicationSettingsModel.ExternalTools.Keycloak.Host.ToString();

			AdminUsername = ApplicationSettingsModel.ExternalTools.Keycloak.Admin.Username;
			AdminPassword = ApplicationSettingsModel.ExternalTools.Keycloak.Admin.Password;
			AdminRealmName = ApplicationSettingsModel.ExternalTools.Keycloak.Realms.AdminRealm.RealmName;
			AdminClientID = ApplicationSettingsModel.ExternalTools.Keycloak.Realms.AdminRealm.ClientId;
			AdminClientSecret = ApplicationSettingsModel.ExternalTools.Keycloak.Realms.AdminRealm.ClientSecret;
			AdminID = ApplicationSettingsModel.ExternalTools.Keycloak.Admin.AdminID;

			UserRealmName = ApplicationSettingsModel.ExternalTools.Keycloak.Realms.UserRealm.RealmName;
			UserClientID = ApplicationSettingsModel.ExternalTools.Keycloak.Realms.UserRealm.ClientId;
			UserClientSecret = ApplicationSettingsModel.ExternalTools.Keycloak.Realms.UserRealm.ClientSecret;

			TokenRoute = ApplicationSettingsModel.ExternalTools.Keycloak.Routes.TokenRoute;
			UsersRoute = ApplicationSettingsModel.ExternalTools.Keycloak.Routes.UsersRoute;
			SessionRoute = ApplicationSettingsModel.ExternalTools.Keycloak.Routes.SessionRoute;
			IntrospectRoute = ApplicationSettingsModel.ExternalTools.Keycloak.Routes.IntrospectRoute;

			Dictionary<string, string> ConfigList = new Dictionary<string, string>()
			{
				{ "KeycloakHost", KeycloakHost },
				{ "AdminUsername", AdminUsername },
				{ "AdminPassword", AdminPassword },
				{ "AdminRealmName", AdminRealmName },
				{ "AdminClientID", AdminClientID },
				{ "AdminClientSecret", AdminClientSecret },
				{ "UserRealmName", UserRealmName },
				{ "UserClientID", UserClientID },
				{ "UserClientSecret", UserClientSecret },
				{ "AdminID", AdminID },
				{ "TokenRoute", TokenRoute },
				{ "UsersRoute", UsersRoute },
				{ "SessionRoute", SessionRoute },
				{ "IntrospectRoute", IntrospectRoute }
			};

			return ConfigList;

		}

		public Dictionary<string, string> GetElasticSearchConfig()
		{
			DefaultIndexName = ApplicationSettingsModel.ExternalTools.ElasticSearch.DefaultIndexName.ToString();
			ElasticHost = ApplicationSettingsModel.ExternalTools.ElasticSearch.Host.ToString();
			ElasticRootUsername = ApplicationSettingsModel.ExternalTools.ElasticSearch.Admin.Username;
			ElasticRootPassword = ApplicationSettingsModel.ExternalTools.ElasticSearch.Admin.Password;

			Dictionary<string, string> ConfigList = new Dictionary<string, string>()
			{
				{ "ElasticHost", ElasticHost },
				{ "ElasticRootUsername", ElasticRootUsername },
				{ "ElasticRootPassword", ElasticRootPassword },
				{ "DefaultIndexName", DefaultIndexName }
			};

			return ConfigList;

		}

		public Dictionary<string, string> GetMongoDBConfig()
		{
			DefaultDatabaseName = ApplicationSettingsModel.ExternalTools.MongoDB.DefaultDatabaseName.ToString();
			MongoDBConnectionString = ApplicationSettingsModel.ExternalTools.MongoDB.ConnectionString.ToString();
			MongoDBHost = ApplicationSettingsModel.ExternalTools.MongoDB.Host.ToString();

			Dictionary<string, string> ConfigList = new Dictionary<string, string>()
			{
				{ "MongoDBHost", MongoDBHost },
				{ "DefaultDatabaseName", DefaultDatabaseName },
				{ "MongoDBConnectionString", MongoDBConnectionString }
			};

			return ConfigList;

		}

		public Dictionary<string, string> GetRedisConfig()
		{
			RedisHost = ApplicationSettingsModel.ExternalTools.Redis.Host.ToString();
			Password = ApplicationSettingsModel.ExternalTools.Redis.Password.ToString();

			Dictionary<string, string> ConfigList = new Dictionary<string, string>()
			{
				{ "RedisHost", RedisHost },
				{ "Password", Password }
			};

			return ConfigList;

		}


		public Dictionary<string, string> GetMSSQLConfig()
		{
			Host = ApplicationSettingsModel.ExternalTools.Mssql.Host.ToString();
			Username = ApplicationSettingsModel.ExternalTools.Mssql.Username.ToString();
			MSSQLPassword = ApplicationSettingsModel.ExternalTools.Mssql.MSSQLPassword.ToString();
			DBName = ApplicationSettingsModel.ExternalTools.Mssql.DBName.ToString();

			Dictionary<string, string> ConfigList = new Dictionary<string, string>()
			{
				{ "Host", Host },
				{ "Username", Username },
				{ "MSSQLPassword", MSSQLPassword },
				{ "DBName", DBName }
			};

			return ConfigList;

		}

	}
}
