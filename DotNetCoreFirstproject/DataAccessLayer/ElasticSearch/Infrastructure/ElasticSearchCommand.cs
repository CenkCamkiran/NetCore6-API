using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Entities;
using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Infrastructure
{
	public class ElasticSearchCommand : ElasticSearchConnection, IElasticSearchCommand
	{

		private ElasticSearchConnection elasticConn; 

		public ElasticSearchCommand()
		{
			elasticConn = new ElasticSearchConnection();
		}

		public void InsertDocument(ControllerRequestResponseModel document)
		{
			try
			{

				var cenk = new
				{
					Number = 5,
					Name = "Test"
				};
				var indexResult = elasticConn.ElasticSearchClient.IndexDocument(cenk);
				Console.WriteLine("Index ID: " + indexResult.Id);
				Console.WriteLine("Index Name: " + indexResult.Index);
				Console.WriteLine("Result Code: " + indexResult.Result);
				Console.WriteLine("Is Valid: " + indexResult.IsValid);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
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
