using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;
using Helpers.AppExceptionHelpers;
using Helpers.HttpClientHelpers;
using Configurations;
using Models.HelpersModels;
using Models.ControllerModels;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
	public class KeycloakService : AppConfiguration, IKeycloakService
    {
        private AppConfiguration appConfiguration;

        public KeycloakService()
        {
            appConfiguration = new AppConfiguration();
        }

        public TokenResponse? AdminAuth()
		{

            TokenResponse? responseBody = default;
			HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = appConfiguration.GetKeycloakConfig();
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
                responseBody = JsonConvert.DeserializeObject<TokenResponse>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = errorResponse.error_description;
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomKeycloakError errorModel = new CustomKeycloakError();
                errorModel.ErrorMessage = errorResponse.error_description;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                errorModel.KeycloakToken = null;

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = "Application Error";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
            }

            return responseBody;

        }

        public TokenResponse? UserAuth(UserLoginRequest userCredentials)
        {
            TokenResponse? responseBody = default;
            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = appConfiguration.GetKeycloakConfig();
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
                responseBody = JsonConvert.DeserializeObject<TokenResponse>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = errorResponse.error_description;
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomKeycloakError errorModel = new CustomKeycloakError();
                errorModel.ErrorMessage = errorResponse.error_description;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                errorModel.KeycloakToken = null;

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = "Application Error";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
            }

            return responseBody;

        }

        public TokenResponse? RefreshSession(bool IsAdmin, TokenResponse token)
        {
            TokenResponse? responseBody = default;
            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = appConfiguration.GetKeycloakConfig();
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
                responseBody = JsonConvert.DeserializeObject<TokenResponse>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = errorResponse.error_description;
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {

                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomKeycloakError errorModel = new CustomKeycloakError();
                errorModel.ErrorMessage = errorResponse.error_description;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                errorModel.KeycloakToken = null;

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
            }
            else
            {

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = "Application Error";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
            }

            return responseBody;

        }

        public HttpResponseMessage RemoveSession(bool IsAdmin, TokenResponse token)
        {

            var newSession = RefreshSession(IsAdmin, token);
            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = appConfiguration.GetKeycloakConfig();
            string WebServiceUrl = IsAdmin ? string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["SessionRoute"], keycloakConfigs["AdminRealmName"], token.session_state)) 
                : string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["SessionRoute"], keycloakConfigs["UserRealmName"], token.session_state));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", newSession.access_token));

            var httpResponseMessage = httpClientHelper.MakeRequestWithoutBodyQueryParams(WebServiceUrl, HttpMethod.Delete, httpHeaders, token);

            if (httpResponseMessage.StatusCode == HttpStatusCode.NoContent)
			{
                return httpResponseMessage;
            }
			else
			{
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var keycloakError = JsonConvert.DeserializeObject<KeycloakGeneralError>(jsonString.Result);

                CustomKeycloakError errorModel = new CustomKeycloakError();
                errorModel.ErrorMessage = keycloakError.error;
                errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(errorModel));

            }

        }

        public UserSignupResponse? CreateUser(CreateUserRequest requestBody, TokenResponse token)
        {

            UserSignupResponse? responseBody = default;
            HttpClientHelper<CreateUserRequest> httpClientHelper = new HttpClientHelper<CreateUserRequest>();

            var keycloakConfigs = appConfiguration.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["UsersRoute"], keycloakConfigs["UserRealmName"]));

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            httpHeaders.Add(HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", token.access_token));

            var httpResponseMessage = httpClientHelper.MakeJSONRequest(WebServiceUrl, requestBody, HttpMethod.Post, httpHeaders, token);

            if (httpResponseMessage.StatusCode == HttpStatusCode.Created)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<UserSignupResponse>(jsonString.Result);

            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponse>(jsonString.Result);

                if (token == null)
                {
                    CustomAppError customAppErrorModel = new CustomAppError();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else
                {
                    CustomKeycloakError errorModel = new CustomKeycloakError();
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
                    CustomAppError customAppErrorModel = new CustomAppError();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else
                {
                    var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                    var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponse>(jsonString.Result);

                    CustomKeycloakError errorModel = new CustomKeycloakError();
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
                    CustomAppError customAppErrorModel = new CustomAppError();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else
                {
                    CustomKeycloakError errorModel = new CustomKeycloakError();
                    errorModel.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();
                    errorModel.KeycloakToken = token;

                    throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                }

            }

            var RemoveSessionResult = RemoveSession(true, token); //If error comes what to do?

            return responseBody;

        }

		public DecodedToken CheckTokenStatus(string token)
		{

            DecodedToken? responseBody = default;

            HttpClientHelper<string> httpClientHelper = new HttpClientHelper<string>();

            var keycloakConfigs = appConfiguration.GetKeycloakConfig();
            string WebServiceUrl = string.Concat(keycloakConfigs["Host"], string.Format(keycloakConfigs["IntrospectRoute"], keycloakConfigs["UserRealmName"]));

            Dictionary<string, string> requestForm = new Dictionary<string, string>();
            requestForm["client_id"] = keycloakConfigs["AdminClientID"];
            requestForm["client_secret"] = keycloakConfigs["AdminClientSecret"];
            requestForm["token"] = token;

            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add(HttpRequestHeader.Accept.ToString(), MediaTypeNames.Application.Json);
            httpHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded");

            var httpResponseMessage = httpClientHelper.MakeFormRequest(WebServiceUrl, requestForm, HttpMethod.Post, httpHeaders);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                responseBody = JsonConvert.DeserializeObject<DecodedToken>(jsonString.Result);

                return responseBody;

            }
            else
            {

                CustomAppError customAppErrorModel = new CustomAppError();
                customAppErrorModel.ErrorMessage = "Keycloak IntrospectRoute Exception";
                customAppErrorModel.ErrorCode = ((int)httpResponseMessage.StatusCode).ToString();

                throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
            }

        }
	}
}
