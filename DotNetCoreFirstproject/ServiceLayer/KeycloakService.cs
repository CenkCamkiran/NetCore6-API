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

        public async Task<TokenResponseModel> AdminAuth()
        {

            HttpClientHelper<string, TokenResponseModel> httpClientHelper = new HttpClientHelper<string, TokenResponseModel>();
            
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

        public async Task<TokenResponseModel> RefreshSession(TokenResponseModel token)
        {

            HttpClientHelper<string, TokenResponseModel> httpClientHelper = new HttpClientHelper<string, TokenResponseModel>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["AdminRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = keycloakConfigs["ClientID"];
            requestForm["refresh_token"] = token.refresh_token;
            requestForm["grant_type"] = "refresh_token";
            requestForm["client_secret"] = keycloakConfigs["ClientSecret"];

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded"); //MediaTypeNames.Application.???
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);

            var APIResult = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            return APIResult;

        }

        public async Task<object> RemoveSession(bool IsAdmin, TokenResponseModel token) //Remove a specific user session: 204 No Content cevabı geliyor.
        {

            TokenResponseModel mewSession = await RefreshSession(token);
            HttpClientHelper<string, object> httpClientHelper = new HttpClientHelper<string, object>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = IsAdmin ? string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["SessionRoute"], keycloakConfigs["AdminRealmName"], token.session_state)) 
                : string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["SessionRoute"], keycloakConfigs["UserRealmName"], token.session_state));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", mewSession.access_token));

            var APIResult = httpClientHelper.MakeRequestWithoutBodyQueryParams(WebServiceUrl, HttpMethod.Delete, httpHeaders);

            return APIResult;

        }

        public async Task<UserSignupResponseModel> CreateUser(CreateUserRequestModel requestBody, TokenResponseModel token)
        {

            HttpClientHelper<CreateUserRequestModel, UserSignupResponseModel> httpClientHelper = new HttpClientHelper<CreateUserRequestModel, UserSignupResponseModel>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigHelper.Host, string.Format(keycloakConfigs["UsersRoute"], keycloakConfigs["UserRealmName"]));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", token.access_token));

            var APIResult = httpClientHelper.MakeJSONRequest(WebServiceUrl, requestBody, HttpMethod.Post, httpHeaders);

            var RemoveSessionResult = await RemoveSession(true, token); //If error comes what to do?

            return APIResult;

        }

    }
}
