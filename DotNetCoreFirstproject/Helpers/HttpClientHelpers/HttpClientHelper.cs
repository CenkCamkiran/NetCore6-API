using Newtonsoft.Json;
using System.Text;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using System.Net;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;

namespace DotNetCoreFirstproject.Helpers.HttpClientHelper
{
    public class HttpClientHelper<TRequestBody, TResponseBody>
    {

        private HttpClientHandler httpClientHandler;

        public HttpClientHelper()
        {
            httpClientHandler = new HttpClientHandler();    
        }

        // application/x-www-form-urlencoded
        public TResponseBody MakeFormRequest(string WebServiceUrl, Dictionary<string, string> FormData, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            TResponseBody? responseBody = default;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
            foreach (var requestHeader in RequestHeaders)
            {
                httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
            }
            httpRequestMessage.Content = new FormUrlEncodedContent(FormData);

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {

                httpClient.BaseAddress = new Uri(WebServiceUrl);
                var httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.Result.StatusCode == HttpStatusCode.OK)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);

                }
                else if (httpResponseMessage.Result.StatusCode == HttpStatusCode.BadRequest) 
                {

                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                    CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                    customAppErrorModel.ErrorMessage = errorResponse.error_description;
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                    throw new KeycloakException(JsonConvert.SerializeObject(customAppErrorModel));
                }
                else if (httpResponseMessage.Result.StatusCode == HttpStatusCode.Unauthorized)
                {

                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<KeycloakGeneralErrorModel>(jsonString.Result);

                    CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                    errorModel.ErrorMessage = errorResponse.error_description;
                    errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();
                    errorModel.KeycloakToken = null;

                    throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                }
                else
                {

                    CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                    customAppErrorModel.ErrorMessage = "Application Error";
                    customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                    throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                }

            }

            return responseBody;

        }

        // application/json
        public TResponseBody MakeJSONRequest(string WebServiceUrl, TRequestBody JSONBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders, TokenResponseModel? Token = null)
        {

            TResponseBody? responseBody = default;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
            foreach (var requestHeader in RequestHeaders)
            {
                httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
            }
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONBody), Encoding.UTF8, "application/json");

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {

                httpClient.BaseAddress = new Uri(WebServiceUrl);
                var httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.Result.StatusCode == HttpStatusCode.Created)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);

                } else if (httpResponseMessage.Result.StatusCode == HttpStatusCode.Conflict)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponseModel>(jsonString.Result);

                    if (Token == null)
                    {
                        CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                        customAppErrorModel.ErrorMessage = "Application Error";
                        customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                        throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                    }
                    else
                    {

                        CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                        errorModel.ErrorMessage = createUserErrorResponseModel.errorMessage;
                        errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();
                        errorModel.KeycloakToken = Token;

                        throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                    }

                }
				else if (httpResponseMessage.Result.StatusCode == HttpStatusCode.BadRequest)
				{

                    if (Token == null)
                    {
                        CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                        customAppErrorModel.ErrorMessage = "Application Error";
                        customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                        throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                    }
                    else
                    {

                        var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                        var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponseModel>(jsonString.Result);

                        CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                        errorModel.ErrorMessage = createUserErrorResponseModel.errorMessage;
                        errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();
                        errorModel.KeycloakToken = Token;

                        throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                    }

                }
                else
                {

                    if (Token == null)
                    {
                        CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                        customAppErrorModel.ErrorMessage = "Application Error";
                        customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                        throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                    }
                    else
                    {
                        CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                        errorModel.ErrorMessage = "HTTP 500 Internal Server Error";
                        errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();
                        errorModel.KeycloakToken = Token;

                        throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                    }

                }

            }

            return responseBody;
        }

        //No JSON Body / Query Params
        public TResponseBody MakeRequestWithoutBodyQueryParams(string WebServiceUrl, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders, TokenResponseModel? Token = null)
        {

            TResponseBody? responseBody = default;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
            foreach (var requestHeader in RequestHeaders)
            {
                httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
            }

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {

                httpClient.BaseAddress = new Uri(WebServiceUrl);
                var httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.Result.StatusCode == HttpStatusCode.NoContent)
                {
                    //Success

                } else if (httpResponseMessage.Result.StatusCode == HttpStatusCode.Unauthorized)
                {

                    if (Token == null)
                    {
                        CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                        customAppErrorModel.ErrorMessage = "Unauthorized";
                        customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                        throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                    }
                    else
                    {
                        CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                        errorModel.ErrorMessage = "HTTP 401 Unauthorized";
                        errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();
                        errorModel.KeycloakToken = Token;

                        throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                    }

                }
                else
                {

                    if (Token == null)
                    {
                        CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
                        customAppErrorModel.ErrorMessage = "Application Error";
                        customAppErrorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                        throw new AppException(JsonConvert.SerializeObject(customAppErrorModel));
                    }
                    else
                    {
                        CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                        errorModel.ErrorMessage = "HTTP 500 Internal Server Error";
                        errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();
                        errorModel.KeycloakToken = Token;

                        throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                    }

                }

            }

            return responseBody;
        }

        //Query string
        public TResponseBody MakeQueryParamRequest(string WebServiceUrl, TRequestBody JSONBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            TResponseBody? responseBody = default;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
            foreach (var requestHeader in RequestHeaders)
            {
                httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
            }
            httpRequestMessage.Content = new StringContent(JSONBody.ToString(), Encoding.UTF8, "application/json");

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {

                httpClient.BaseAddress = new Uri(WebServiceUrl);
                var httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.Result.StatusCode == HttpStatusCode.Created)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);

                }
                else
                {
                    CustomKeycloakErrorModel errorModel = new CustomKeycloakErrorModel();
                    errorModel.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorModel.ErrorCode = ((int)httpResponseMessage.Result.StatusCode).ToString();

                    throw new KeycloakException(JsonConvert.SerializeObject(errorModel));
                }


            }

            return responseBody;
        }

    }
}
