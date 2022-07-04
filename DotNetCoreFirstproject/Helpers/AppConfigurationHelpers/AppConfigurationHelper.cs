using DotNetCoreFirstproject.Configuration;

namespace DotNetCoreFirstproject.Helpers.AppConfigurationHelpers
{
    public partial class AppConfigurationHelper
    {

        public Dictionary<string, string> GetKeycloakConfig()
        {

            Host = ApplicationSettings.ExternalTools.Keycloak.Host.ToString();

            AdminUsername = ApplicationSettings.ExternalTools.Keycloak.Admin.Username;
            AdminPassword = ApplicationSettings.ExternalTools.Keycloak.Admin.Password;
            AdminRealmName = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.RealmName;
            AdminClientID = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientId;
            AdminClientSecret = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientSecret;
            AdminID = ApplicationSettings.ExternalTools.Keycloak.Admin.AdminID;

            UserRealmName = ApplicationSettings.ExternalTools.Keycloak.Realms.UserRealm.RealmName;
            UserClientID = ApplicationSettings.ExternalTools.Keycloak.Realms.UserRealm.ClientId;
            UserClientSecret = ApplicationSettings.ExternalTools.Keycloak.Realms.UserRealm.ClientSecret;

            TokenRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.TokenRoute;
            UsersRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.UsersRoute;
            SessionRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.SessionRoute;

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
            DefaultIndexName = ApplicationSettings.ExternalTools.ElasticSearch.DefaultIndexName.ToString();
            ElasticHost = ApplicationSettings.ExternalTools.ElasticSearch.Host.ToString();
            ElasticRootUsername = ApplicationSettings.ExternalTools.ElasticSearch.Admin.Username;
            ElasticRootPassword = ApplicationSettings.ExternalTools.ElasticSearch.Admin.Password;

            Dictionary<string, string> ConfigList = new Dictionary<string, string>()
            {
                { "ElasticHost", ElasticHost },
                { "ElasticRootUsername", ElasticRootUsername },
                { "ElasticRootPassword", ElasticRootPassword },
                { "DefaultIndexName", DefaultIndexName }
            };

            return ConfigList;

        }

    }
}
