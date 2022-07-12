using DataAccessLayer.ElasticSearch.Interfaces;
using Helpers.AppExceptionHelpers;
using Nest;
using Elasticsearch.Net;
using Newtonsoft.Json;
using System.Net;
using Models.HelpersModels;
using Models.DataAccessLayerModels;

namespace DataAccessLayer.ElasticSearch.Infrastructure
{
	public class ElasticSearchCommand : ElasticSearchConnection, IElasticSearchCommand
	{

		private ElasticSearchConnection elasticConn; 

		public ElasticSearchCommand()
		{
			elasticConn = new ElasticSearchConnection();
		}

		//ControllerRequestResponseModel
		public void IndexData(ControllerRequestResponseLog? document)
		{
			IndexResponse? indexResult = default;

			try
			{

				//var cenk = elasticConn.ElasticSearchClient.LowLevel.Index<StringResponse>("controller-logs-index", PostData.Serializable(document));
				//Console.WriteLine("Success: " + cenk.Success);
				//Console.WriteLine("HTTP Status Code: " + cenk.HttpStatusCode);

				indexResult = elasticConn.ElasticSearchClient.IndexDocument(document);
				Console.WriteLine("Index ID: " + indexResult.Id);
				Console.WriteLine("Index Name: " + indexResult.Index);
				Console.WriteLine("Result Code: " + indexResult.Result);
				Console.WriteLine("Is Valid: " + indexResult.IsValid);
				Console.WriteLine("Server Error: " + indexResult.ServerError);
				Console.WriteLine("API Call HTTP Status Code: " + indexResult.ApiCall.HttpStatusCode);
				Console.WriteLine("API Call Original Exception: " + indexResult.ApiCall.OriginalException);
				Console.WriteLine("API Call Success: " + indexResult.ApiCall.Success);

			}
			catch (Exception exception)
			{

				CustomAppError customAppErrorModel = new CustomAppError();
				customAppErrorModel.ErrorMessage = exception.Message.ToString() + " - " + indexResult?.ApiCall.OriginalException.Message.ToString();
				customAppErrorModel.ErrorCode = indexResult?.ApiCall.HttpStatusCode == null ? ((int)HttpStatusCode.InternalServerError).ToString() : ((int)HttpStatusCode.OK).ToString();

				throw new ElasticSearchException(JsonConvert.SerializeObject(customAppErrorModel));
			}

		}

		public void SearchDocument(object document)
		{
			try
			{

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void UpdateDocument(object document)
		{
			try
			{

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void DeleteDocument(object document)
		{
			try
			{

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

	}
}
