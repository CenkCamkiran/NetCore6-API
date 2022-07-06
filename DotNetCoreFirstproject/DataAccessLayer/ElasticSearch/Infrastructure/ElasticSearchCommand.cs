﻿using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Entities;
using DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Interfaces;
using DotNetCoreFirstproject.Helpers.AppExceptionHelpers;
using DotNetCoreFirstproject.Helpers.Entities.Keycloak;
using Nest;

namespace DotNetCoreFirstproject.DataAccessLayer.ElasticSearch.Infrastructure
{
	public class ElasticSearchCommand : ElasticSearchConnection, IElasticSearchCommand
	{

		private ElasticSearchConnection elasticConn; 

		public ElasticSearchCommand()
		{
			elasticConn = new ElasticSearchConnection();
		}

		public void IndexData(ControllerRequestResponseModel document)
		{

			IndexResponse? indexResult = default;

			try
			{

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

				CustomAppErrorModel customAppErrorModel = new CustomAppErrorModel();
				customAppErrorModel.ErrorMessage = exception.Message.ToString() + " - " + indexResult.ApiCall.OriginalException;
				customAppErrorModel.ErrorCode = (indexResult.ApiCall.HttpStatusCode).ToString();

				throw new ElasticSearchException();
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
