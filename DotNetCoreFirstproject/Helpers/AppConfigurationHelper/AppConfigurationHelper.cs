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

        public Dictionary<string, string> GetKeycloakConfig()
        {

            Host = ApplicationSettings.ExternalTools.Keycloak.Host.ToString();
            AdminUsername = ApplicationSettings.ExternalTools.Keycloak.Admin.Username;
            AdminPassword = ApplicationSettings.ExternalTools.Keycloak.Admin.Password;
            AdminRealmName = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.RealmName;
            ClientID = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientId;
            ClientSecret = ApplicationSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientSecret;
            TokenRoute = ApplicationSettings.ExternalTools.Keycloak.Routes.TokenRoute;

            Dictionary<string, string> ConfigList = new Dictionary<string, string>()
            {
                { "Host", Host },
                { "AdminUsername", AdminUsername },
                { "AdminPassword", AdminPassword },
                { "AdminRealmName", AdminRealmName },
                { "ClientID", ClientID },
                { "ClientSecret", ClientSecret },
                { "TokenRoute", TokenRoute }
            };

            return ConfigList;

        }

        public Dictionary<string, string> GetElasticSearchConfig()
        {

            return null;

        }

    }
}
