﻿using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.AppConfigurationHelpers;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using DotNetCoreFirstproject.Helpers.HttpClientHelper;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser;
using DotNetCoreFirstproject.ServiceLayer.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace DotNetCoreFirstproject.ServiceLayer
{
    public class KeycloakService : AppConfigurationHelper
    {
        private AppConfigurationHelper keycloakConfigHelper;

        public KeycloakService()
        {
            keycloakConfigHelper = new AppConfigurationHelper();
        }

        public async Task<TokenResponseModel> AdminAuth()
		{

            TokenResponseModel? responseBody = default;
			HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["AdminRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = keycloakConfigs["AdminClientID"];
            requestForm["username"] = keycloakConfigs["AdminUsername"];
            requestForm["password"] = keycloakConfigs["AdminPassword"];
            requestForm["grant_type"] = "password";
            requestForm["client_secret"] = keycloakConfigs["AdminClientSecret"];

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded"); //MediaTypeNames.Application.???
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);

            var httpResponseMessage = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<TokenResponseModel>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                customAppErrorModel.ErrorMessage = errorResponse.error_description;
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                errorModel.ErrorMessage = errorResponse.error_description;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                errorModel.KeycloakToken = null;

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {

                CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                customAppErrorModel.ErrorMessage = "Application Error";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
            }

            return responseBody;

        }

        public async Task<TokenResponseModel> UserAuth(UserLoginRequestModel userCredentials)
        {
            TokenResponseModel? responseBody = default;
            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["UserRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = keycloakConfigs["UserClientID"];
            requestForm["username"] = userCredentials.username;
            requestForm["password"] = userCredentials.password;
            requestForm["grant_type"] = "password";
            requestForm["client_secret"] = keycloakConfigs["UserClientSecret"];

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded"); //MediaTypeNames.Application.???
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);

            var httpResponseMessage = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<TokenResponseModel>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                customAppErrorModel.ErrorMessage = errorResponse.error_description;
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                errorModel.ErrorMessage = errorResponse.error_description;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                errorModel.KeycloakToken = null;

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {

                CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                customAppErrorModel.ErrorMessage = "Application Error";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
            }

            return responseBody;

        }

        public async Task<TokenResponseModel> RefreshSession(bool IsAdmin, TokenResponseModel token)
        {
            TokenResponseModel? responseBody = default;
            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = IsAdmin ? string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["AdminRealmName"]))
                : string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["TokenRoute"], keycloakConfigs["UserRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = IsAdmin ? keycloakConfigs["AdminClientID"] : keycloakConfigs["UserClientID"];
            requestForm["refresh_token"] = token.refresh_token;
            requestForm["grant_type"] = "refresh_token";
            requestForm["client_secret"] = IsAdmin? keycloakConfigs["AdminClientSecret"] : keycloakConfigs["UserClientSecret"];

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded"); //MediaTypeNames.Application.???
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);

            var httpResponseMessage = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<TokenResponseModel>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                customAppErrorModel.ErrorMessage = errorResponse.error_description;
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                errorModel.ErrorMessage = errorResponse.error_description;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                errorModel.KeycloakToken = null;

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {

                CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                customAppErrorModel.ErrorMessage = "Application Error";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
            }

            return responseBody;

        }

        public async Task<object> RemoveSession(bool IsAdmin, TokenResponseModel token) //Remove a specific user session: 204 No Content cevabı geliyor.
        {

            var newSession = await RefreshSession(IsAdmin, token);
            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = IsAdmin ? string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["SessionRoute"], keycloakConfigs["AdminRealmName"], token.session_state)) 
                : string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["SessionRoute"], keycloakConfigs["UserRealmName"], token.session_state));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", newSession.access_token));

            var APIResult = httpClientHelper.MakeRequestWithoutBodyQueryParams(WebServiceUrl, HttpMethod.Delete, httpHeaders, token);

            return APIResult;

        }

        public async Task<UserSignupResponseModel> CreateUser(CreateUserRequestModel requestBody, TokenResponseModel token)
        {

            UserSignupResponseModel? responseBody = default;
            HttpClientHelper<CreateUserRequestModel> httpClientHelper = new HttpClientHelper<CreateUserRequestModel>();

            var keycloakConfigs = keycloakConfigHelper.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["UsersRoute"], keycloakConfigs["UserRealmName"]));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", token.access_token));

            var httpResponseMessage = httpClientHelper.MakeJSONRequest(WebServiceUrl, requestBody, HttpMethod.Post, httpHeaders, token);

            if (httpResponseMessage.StatusCode == HttpStatusCode.Created)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<UserSignupResponseModel>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponseModel>(jsonString.Result);

                if (token == null)
                {
                    CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else
                {

                    CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                    errorModel.ErrorMessage = createUserErrorResponseModel.errorMessage;
                    errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                    errorModel.KeycloakToken = token;

                    throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                }

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                if (token == null)
                {
                    CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else
                {

                    var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                    var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponseModel>(jsonString.Result);

                    CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                    errorModel.ErrorMessage = createUserErrorResponseModel.errorMessage;
                    errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                    errorModel.KeycloakToken = token;

                    throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                }

            }
            else
            {

                if (token == null)
                {
                    CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else
                {
                    CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                    errorModel.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                    errorModel.KeycloakToken = token;

                    throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                }

            }

            var RemoveSessionResult = await RemoveSession(true, token); //If error comes what to do?

            return responseBody;

        }

    }
}
