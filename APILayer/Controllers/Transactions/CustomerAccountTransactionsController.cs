using Helpers.AppExceptionHelpers;
using Helpers.StringHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DataAccessLayerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using System.Net;

namespace APILayer.Controllers.Transactions
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class CustomerAccountTransactionsController : ControllerBase
	{

		private ICustomerAccountTransactionsService _customerAccountTransactionsService;

		public CustomerAccountTransactionsController(ICustomerAccountTransactionsService customerAccountTransactionsService)
		{
			_customerAccountTransactionsService = customerAccountTransactionsService;
		}

		[HttpGet("Id/{Id}")]
		public CustomerAccountTransactions GetCustomerAccountTransactionsById(string Id)
		{

			Id.ControlObjectID(Id);

			List<CustomerAccountTransactions>? result = _customerAccountTransactionsService.GetCustomerAccountTransactionsByAccountId(Id);

			if (result == null)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Data not found";
				errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

				throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
			}

			return result.SingleOrDefault();
		}
	}
}
