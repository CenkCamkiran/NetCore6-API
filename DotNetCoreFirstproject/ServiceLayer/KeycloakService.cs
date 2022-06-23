using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.AppConfigurationHelper;
using DotNetCoreFirstproject.Helpers.HttpClientHelper;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using System.Net;
using System.Net.Mime;

namespace DotNetCoreFirstproject.ServiceLayer
{
    public class KeycloakService
    {
        private AppConfigurationHelper keycloakConfigHelper;

        public KeycloakService()
        {
            keycloakConfigHelper = new AppConfigurationHelper();
        }

        public async Task<Token> AdminAuth()
        {

            HttpClientHelper<string, Token> httpClientHelper = new HttpClientHelper<string, Token>();
            
            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();

            string WebServiceUrl = string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["AdminRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = keycloakConfigs["ClientID"];
            requestForm["username"] = keycloakConfigs["AdminUsername"];
            requestForm["password"] = keycloakConfigs["AdminPassword"];
            requestForm["grant_type"] = "password";
            requestForm["client_secret"] = keycloakConfigs["ClientSecret"];

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded"); //MediaTypeNames.Application.???
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);

            var APIResult = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            return APIResult;

        }

        public async Task<Token> CreateUser()
        {

            HttpClientHelper<string, Token> httpClientHelper = new HttpClientHelper<string, Token>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();

            string WebServiceUrl = string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["AdminRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = keycloakConfigs["ClientID"];
            requestForm["username"] = keycloakConfigs["AdminUsername"];
            requestForm["password"] = keycloakConfigs["AdminPassword"];
            requestForm["grant_type"] = "password";
            requestForm["client_secret"] = keycloakConfigs["ClientSecret"];

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), MediaTypeNames.Application.Json);
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);

            var APIResult = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            return APIResult;

        }

        public UserSignupResponseModel UserSignUp(CreateUser requestBody, Token token)
        {

            HttpClientHelper<CreateUser, UserSignupResponseModel> httpClientHelper = new HttpClientHelper<CreateUser, UserSignupResponseModel>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["UsersRoute"], keycloakConfigs["AdminRealmName"]));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), String.Format("Bearer {0}", token.AccessToken));

            var APIResult = httpClientHelper.MakeJSONRequest(WebServiceUrl, requestBody, HttpMethod.Post, httpHeaders);

            return APIResult;

        }

    }
}
