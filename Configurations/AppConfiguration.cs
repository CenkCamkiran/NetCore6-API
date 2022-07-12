namespace Configurations
{

	public partial class AppConfiguration
    {

        public Dictionary<string, string> GetKeycloakConfig()
        {

            Host = ApplicationSettingsModel.ExternalTools.Keycloak.Host.ToString();

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

            Dictionary<string, string> ConfigList = new Dictionary<string, string>()
            {
                { "Host", Host },
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
                { "SessionRoute", SessionRoute }
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

    }
}
