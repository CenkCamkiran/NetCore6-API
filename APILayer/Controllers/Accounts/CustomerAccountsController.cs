using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace APILayer.Controllers.Accounts
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class CustomerAccountsController : ControllerBase
	{

		private ICustomerAccountsService _customerAccountsService;

		public CustomerAccountsController(ICustomerAccountsService customerAccountsService)
		{
			_customerAccountsService = customerAccountsService;
		}

		[HttpGet("Id/{Id}")]
		public object GetCustomerAccountById(string Id)
		{

			object customerAccount = _customerAccountsService.GetCustomerAccountById(Id);

			return customerAccount;
		}
	}
}
