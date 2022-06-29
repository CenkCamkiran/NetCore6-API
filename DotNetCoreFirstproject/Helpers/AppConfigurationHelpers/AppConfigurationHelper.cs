using DotNetCoreFirstproject.Configuration;

namespace DotNetCoreFirstproject.Helpers.AppConfigurationHelper
{
    public class AppConfigurationHelper
    {

        public string Host { get; set; }    
        public string AdminUsername { get; set; }   
        public string AdminPassword { get; set; }   
        public string AdminRealmName { get; set; }  
        public string AdminClientID { get; set; }    
        public string AdminClientSecret { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string UserRealmName { get; set; }
        public string UserClientID { get; set; }
        public string UserClientSecret { get; set; }
        public string TokenRoute { get; set; }
        public string UsersRoute { get; set; }
        public string SessionRoute { get; set; }
        public string AdminID { get; set; }

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

            return null;

        }

    }
}
