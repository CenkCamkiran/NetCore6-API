using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using Newtonsoft.Json;
using System.Text;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.Entities;
using System.Net;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;

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
        public TResponseBody MakeFormRequest(string WebServiceUrl, Dictionary<string, string> FormData, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders, TokenResponseModel? Token = null)
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
                else
                {
                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorResponse.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                    if (Token == null)
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse));
                    }
                    else
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse), new KeycloakException(Token.refresh_token));
                    }
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

                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = createUserErrorResponseModel.errorMessage;
                    errorResponse.ErrorCode = ((int)HttpStatusCode.Conflict).ToString();

                    if (Token == null)
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse));
                    }
                    else
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse), new KeycloakException(JsonConvert.SerializeObject(Token)));
                    }

                }
                else
                {
                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorResponse.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                    if (Token == null)
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse));
                    }
                    else
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse), new KeycloakException(Token.refresh_token));
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
                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = "HTTP 401 Unauthorized";
                    errorResponse.ErrorCode = ((int)HttpStatusCode.Unauthorized).ToString();

                    if (Token == null)
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse));
                    }
                    else
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse), new KeycloakException(Token.refresh_token));
                    }

                }
                else
                {
                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorResponse.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                    if (Token == null)
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse));
                    }
                    else
                    {
                        throw new KeycloakException(JsonConvert.SerializeObject(errorResponse), new KeycloakException(Token.refresh_token));
                    }

                }

            }

            return responseBody;
        }

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
                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = "HTTP 500 Internal Server Error";
                    errorResponse.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

                    throw new KeycloakException(JsonConvert.SerializeObject(errorResponse));
                }


            }

            return responseBody;
        }

    }
}
