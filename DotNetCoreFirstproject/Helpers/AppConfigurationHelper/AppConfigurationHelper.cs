using DotNetCoreFirstproject.Configuration;

namespace DotNetCoreFirstproject.Helpers.AppConfigurationHelper
{
    public class AppConfigurationHelper
    {

        public string Host { get; set; }    
        public string AdminUsername { get; set; }   
        public string AdminPassword { get; set; }   
        public string AdminRealmName { get; set; }  
        public string ClientID { get; set; }    
        public string ClientSecret { get; set; }    
        public string TokenRoute { get; set; }
        public string UsersRoute { get; set; }
        public string SessionRoute { get; set; }
        public string UserRealmName { get; set; }
        public string AdminID { get; set; }

        public Dictionary<string, string> GetKeycloakConfig()
        {

            Host = ApplicationSettings.ExternalTools.Keycloak.Host.ToString();
            AdminUsername = ApplicationSettings.ExternalTools.Keycloak.Admin.Username;
            AdminPassword = ApplicationSettings.ExternalTools.Keycloak.Admin.Password;
            AdminRealmName = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.RealmName;
            UserRealmName = ApplicationSettings.ExternalTools.Keycloak.Realms.UserRealm.RealmName;
            ClientID = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientId;
            ClientSecret = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientSecret;
            TokenRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.TokenRoute;
            UsersRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.UsersRoute;
            AdminID = ApplicationSettings.ExternalTools.Keycloak.Admin.AdminID;
            SessionRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.SessionRoute;

            Dictionary<string, string> ConfigList = new Dictionary<string, string>()
            {
                { "Host", Host },
                { "AdminUsername", AdminUsername },
                { "AdminPassword", AdminPassword },
                { "AdminRealmName", AdminRealmName },
                { "ClientID", ClientID },
                { "ClientSecret", ClientSecret },
                { "TokenRoute", TokenRoute },
                { "UsersRoute", UsersRoute },
                { "SessionRoute", SessionRoute },
                { "UserRealmName", UserRealmName },
                { "AdminID", AdminID }
            };

            return ConfigList;

        }

        public Dictionary<string, string> GetElasticSearchConfig()
        {

            return null;

        }

    }
}
