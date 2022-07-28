using BusinessLayer.Interfaces;
using Helpers.AppExceptionHelpers;
using Helpers.StringHelpers;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using Models.DataAccessLayerModels;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;

namespace APILayer.Controllers.Customers
{
	[ApiController]
	[Route("rest/api/v1/main/[controller]")]
	public class CustomersController : ControllerBase
	{
		private ICustomersService _customersService;

		public CustomersController(ICustomersService customersService)
		{
			_customersService = customersService;
		}

		[HttpGet]
		public IEnumerable<Customer> GetAllCustomers()
		{

			return _customersService.GetAllCustomers();

		}

		[HttpGet("Id/{Id}")]
		public Customer GetCustomerByID(string Id)
		{

			Id.ControlObjectID(Id);

			Customer customer = _customersService.GetCustomerByID(Id);
			if (customer == null)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Data not found";
				errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

				throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
			}

			return customer;

		}

		[HttpGet("Name/{Name}")]
		public Customer GetCustomerByName(string Name)
		{

			Customer customer = _customersService.GetCustomerByName(Name);
			if (customer == null)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Data not found";
				errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

				throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
			}

			return customer;

		}

		[HttpGet("Email/{Email}")]
		public Customer GetCustomerByEmail(string Email)
		{

			Customer customer = _customersService.GetCustomerByEmail(Email);
			if (customer == null)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Data not found";
				errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

				throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
			}

			return customer;

		}

		[HttpPost("Id/{Id}")]
		public NoContentResult UpdateCustomer(string Id, [FromBody] CustomerRequest customerRequest) //Whole object or specific object?
		{

			Id.ControlObjectID(Id);

			Customer customer = new Customer()
			{
				id = Id,
				accounts = customerRequest.accounts,
				username = customerRequest.username,
				active = customerRequest.active,
				address = customerRequest.address,
				birthdate = customerRequest.birthdate,
				email = customerRequest.email,
				fullname = customerRequest.fullname,
				tierAndDetails = new Dictionary<string, TierAndDetail>()
			};

			foreach (var item in customerRequest.tierAndDetails)
			{
				TierAndDetail tierAndDetail = new TierAndDetail()
				{
					id = item.Value.id,
					active = item.Value.active,
					benefits = item.Value.benefits,
					tier = item.Value.tier
				};

				customer.tierAndDetails.Add(item.Key, tierAndDetail);
			}

			_customersService.UpdateCustomer(Id, customer);

			return NoContent();

		}

		[HttpPost]
		public NoContentResult InsertCustomer([FromBody] CustomerRequest customerRequest) //Whole object or specific object?
		{

			_customersService.InsertCustomer(customerRequest);

			return NoContent();

		}

		//[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		//Query Param
		//[HttpGet]
		//public Customer GetCustomerByName([FromQuery] string Name)


	}
}
