using DotNetCoreFirstproject.Helpers.Entities;
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
        public object MakeFormRequest(string WebServiceUrl, Dictionary<string, string> FormData, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            object? responseBody = default;

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
        public IEnumerable<TResponseBody> MakeJSONRequest(string WebServiceUrl, string ServiceRoute, TRequestBody JSONRequestBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            //IEnumerable<TResponseBody>? responseBody = default;

            //try
            //{
            //    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
            //    foreach (var requestHeader in RequestHeaders)
            //    {
            //        httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
            //    }

            //    //var person = new Person("John Doe", "gardener");

            //    //var json = JsonConvert.SerializeObject(person);
            //    //var data = new StringContent(json, Encoding.UTF8, "application/json");

            //    HttpClient httpClient = _httpClientFactory.CreateClient();
            //    var httpResponseMessage = httpClient.Send(httpRequestMessage);

            //    // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //    // httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");

            //    if (httpResponseMessage.IsSuccessStatusCode)
            //    {

            //        using (var responseStream = httpResponseMessage.Content.ReadAsStream())
            //        {
            //            responseBody = JsonSerializer.Deserialize<IEnumerable<TResponseBody>>(responseStream);
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{


            //}

            return null;
        }

    }
}
