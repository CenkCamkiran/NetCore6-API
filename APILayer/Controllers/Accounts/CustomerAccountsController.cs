using Helpers.AppExceptionHelpers;
using Helpers.StringHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.DataAccessLayerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using System.Net;

namespace APILayer.Controllers.Accounts
{
	[Route("rest/api/v1/main/[controller]")]
	[ApiController]
	public class CustomerAccountsController : ControllerBase
	{

		private ICustomerAccountsService _customerAccountsService;

		public CustomerAccountsController(ICustomerAccountsService customerAccountsService)
		{
			_customerAccountsService = customerAccountsService;
		}

		[HttpGet("Id/{Id}")]
		public CustomerAccounts GetCustomerAccountById(string Id)
		{

			Id.ControlObjectID(Id);

			List<CustomerAccounts> customerAccounts = _customerAccountsService.GetCustomerAccountById(Id);

			if (customerAccounts == null)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Data not found";
				errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

				throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
			}

			return customerAccounts.SingleOrDefault();
		}
	}
}
