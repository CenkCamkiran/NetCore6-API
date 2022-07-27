using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace APILayer.Controllers.Transactions
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class CustomerTransactionsController : ControllerBase
	{

		private ICustomerAccountTransactionsService _customerTransactionsService;

		public CustomerTransactionsController(ICustomerAccountTransactionsService customerTransactionsService)
		{
			_customerTransactionsService = customerTransactionsService;
		}

		[HttpGet("Id/{Id}")]
		public object GetCustomerAccountById(string Id)
		{

			return _customerTransactionsService.GetCustomerAccountTransactionsByAccountId(Id);
		}
	}
}

