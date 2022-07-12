using Models.HelpersModels;
using Newtonsoft.Json;
using System.Text;

namespace Helpers.HttpClientHelpers
{
	public class HttpClientHelper<TRequestBody>
	{

		private HttpClientHandler httpClientHandler;

		public HttpClientHelper()
		{
			httpClientHandler = new HttpClientHandler();
		}

		// application/x-www-form-urlencoded
		public HttpResponseMessage MakeFormRequest(string WebServiceUrl, Dictionary<string, string> FormData, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
		{

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

				return httpResponseMessage.Result;

			}

		}

		// application/json
		public HttpResponseMessage MakeJSONRequest(string WebServiceUrl, TRequestBody JSONBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders, TokenResponse? Token = null)
		{

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

				return httpResponseMessage.Result;

			}

		}

		//No JSON Body / Query Params
		public HttpResponseMessage MakeRequestWithoutBodyQueryParams(string WebServiceUrl, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders, TokenResponse? Token = null)
		{

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

				return httpResponseMessage.Result;

			}

		}

		//Query string
		public HttpResponseMessage MakeQueryParamRequest(string WebServiceUrl, TRequestBody JSONBody, HttpMethod HTTPMethod, Dictionary<string, string> RequestHeaders)
		{

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

				return httpResponseMessage.Result;

			}

		}

	}
}
