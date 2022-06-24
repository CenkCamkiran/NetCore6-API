using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using Newtonsoft.Json;
using System.Text;
using DotNetCoreFirstproject.Helpers.APIExceptionHelper;
using DotNetCoreFirstproject.Helpers.Entities;

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

                if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);

                }
                else
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);
                }

            }

            return responseBody;

        }

        // application/json
        public TResponseBody MakeJSONRequest(string WebServiceUrl, TRequestBody JSONBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            TResponseBody? responseBody = default;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
            foreach (var requestHeader in RequestHeaders)
            {
                httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
            }
            var cenk = new StringContent(JsonConvert.SerializeObject(JSONBody), Encoding.UTF8, "application/json");
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONBody), Encoding.UTF8, "application/json");

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {

                httpClient.BaseAddress = new Uri(WebServiceUrl);
                var httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);

                } else if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponseModel>(jsonString.Result);

                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = createUserErrorResponseModel.errorMessage;
                    errorResponse.ErrorCode = ((int)System.Net.HttpStatusCode.Conflict).ToString();
                    throw new AppException(errorResponse.ToString());

                }
                else
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);
                    var createUserErrorResponseModel = JsonConvert.DeserializeObject<CreateUserErrorResponseModel>(jsonString.Result);

                    CustomErrorResponseModel errorResponse = new CustomErrorResponseModel();
                    errorResponse.ErrorMessage = createUserErrorResponseModel.errorMessage;
                    errorResponse.ErrorCode = ((int)System.Net.HttpStatusCode.Conflict).ToString();
                    throw new AppException(errorResponse.ToString());

                }

            }

            return responseBody;
        }

        //No JSON Body / Query Params
        public TResponseBody MakeRequestWithoutBodyQueryParams(string WebServiceUrl, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
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

                if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    //Success

                } else if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {

                }
                else
                {

                }

            }

            return responseBody;
        }

        public TResponseBody MakeQueryStringRequest(string WebServiceUrl, TRequestBody JSONBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
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

                if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var jsonString = httpResponseMessage.Result.Content.ReadAsStringAsync();
                    responseBody = JsonConvert.DeserializeObject<TResponseBody>(jsonString.Result);

                }

            }

            return responseBody;
        }

    }
}
