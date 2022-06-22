using DotNetCoreFirstproject.Configuration;
using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace DotNetCoreFirstproject.ServiceLayer
{
    public class KeycloakService
    {
        public ConfigurationBuilder configurationBuilder;

        public KeycloakService()
        {
            configurationBuilder = new ConfigurationBuilder();
        }

        public async Task AdminAuth()
        {

            HttpClientHelper<string, Token> httpClientHelper = new HttpClientHelper<string, Token>();

            string Host = ProjectSettings.ExternalTools.Keycloak.Host.ToString();
            string AdminUsername = ProjectSettings.ExternalTools.Keycloak.Admin.Username;
            string AdminPassword = ProjectSettings.ExternalTools.Keycloak.Admin.Password;
            string AdminRealmName = ProjectSettings.ExternalTools.Keycloak.Realms.AdminRealm.RealmName;
            string ClientID = ProjectSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientId;
            string ClientSecret = ProjectSettings.ExternalTools.Keycloak.Realms.AdminRealm.ClientSecret;
            string TokenRoute = ProjectSettings.ExternalTools.Keycloak.Routes.TokenRoute;

            string WebServiceUrl = string.Concat(Host, string.Format(TokenRoute, AdminRealmName));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = ClientID;
            requestForm["username"] = AdminUsername;
            requestForm["password"] = AdminPassword;
            requestForm["grant_type"] = "password";
            requestForm["client_secret"] = ClientSecret;

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded");
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), "application/json");

            var result = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

        }

        public IEnumerable<Token> UserSignUp(UsersignupModel requestBody)
        {
            return null;

        }

    }
}
