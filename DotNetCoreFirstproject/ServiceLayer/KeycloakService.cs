using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using Microsoft.Net.Http.Headers;

namespace DotNetCoreFirstproject.ServiceLayer
{
    public class KeycloakService
    {
        private readonly IConfiguration _configuration;

        public KeycloakService()
        {

        }

        public KeycloakService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Token> AdminAuth()
        {
            HttpClientHelper<string, Token> httpClientHelper = new HttpClientHelper<string, Token>();

            string Host = _configuration["ExternalTools:Keycloak:Host"];
            string AdminUsername = _configuration["ExternalTools:Keycloak:Admin:Username"];
            string AdminPassword = _configuration["ExternalTools:Keycloak:Admin:Password"];
            string AdminRealmName = _configuration["ExternalTools:Keycloak:Realms:AdminRealm:RealmName"];
            string ClientID = _configuration["ExternalTools:Keycloak:Realms:AdminRealm:ClientID"];
            string ClientSecret = _configuration["ExternalTools:Keycloak:Realms:AdminRealm:ClientSecret"];
            string TokenRoute = _configuration["ExternalTools:Keycloak:Routes:TokenRoute"];

            string WebServiceUrl = string.Concat(Host, string.Format(TokenRoute, AdminRealmName));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = ClientID;
            requestForm["username"] = AdminUsername;
            requestForm["password"] = AdminPassword;
            requestForm["grant_type"] = "password";
            requestForm["client_secret"] = ClientSecret;

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HeaderNames.ContentType, "application/x-www-form-urlencoded");
            httpHeaders.Add(HeaderNames.Accept, "application/json");

            var result = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            return result;
        }

        public IEnumerable<Token> UserSignUp(UsersignupModel requestBody)
        {
            return null;

        }

    }
}
