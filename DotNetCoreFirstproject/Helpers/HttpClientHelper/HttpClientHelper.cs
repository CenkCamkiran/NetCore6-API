using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
