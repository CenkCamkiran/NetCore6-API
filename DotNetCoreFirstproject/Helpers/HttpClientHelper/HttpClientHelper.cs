using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DotNetCoreFirstproject.Helpers.HttpClientHelper
{
    public class HttpClientHelper<TResponseBody>
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HttpClientHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<TResponseBody> MakeAdminRequest(string WebServiceUrl, string ServiceRoute, Dictionary<string, string> FormData, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            IEnumerable<TResponseBody>? responseBody = default;

            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
                foreach (var requestHeader in RequestHeaders)
                {
                    httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
                }

                HttpClient httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = httpClient.Send(httpRequestMessage, new FormUrlEncodedContent(FormData),);

                // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
                // httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");

                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    using (var responseStream = httpResponseMessage.Content.ReadAsStream())
                    {
                        responseBody = JsonSerializer.Deserialize<IEnumerable<TResponseBody>>(responseStream);
                    }

                }
            }
            catch (Exception ex)
            {


            }

            return responseBody;
        }

        public IEnumerable<TResponseBody> MakeUserRequest(string WebServiceUrl, string ServiceRoute, TRequestBody JSONRequestBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
        {

            IEnumerable<TResponseBody>? responseBody = default;

            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HTTPMethod, WebServiceUrl);
                foreach (var requestHeader in RequestHeaders)
                {
                    httpRequestMessage.Headers.Add(requestHeader.Key.ToString(), requestHeader.Value);
                }

                HttpClient httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = httpClient.Send(httpRequestMessage);

                // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
                // httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");

                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    using (var responseStream = httpResponseMessage.Content.ReadAsStream())
                    {
                        responseBody = JsonSerializer.Deserialize<IEnumerable<TResponseBody>>(responseStream);
                    }

                }
            }
            catch (Exception ex)
            {


            }

            return responseBody;
        }

    }
}
