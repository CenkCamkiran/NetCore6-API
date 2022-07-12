using BusinessLayer;
using Helpers.AppExceptionHelpers;
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
		private CustomersService customersService;

		public CustomersController()
		{
			customersService = new CustomersService();	
		}

		[HttpGet("Id/{Id}")]
		public Customer GetCustomerByID(string Id)
		{

			if (Id.Length != 24)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Id must be 24 Character length";
				errorModel.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

				throw new AppException(JsonConvert.SerializeObject(errorModel));
			}

			Customer customer = customersService.GetCustomerByID(Id);
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

			Customer customer = customersService.GetCustomerByName(Name);
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

			Customer customer = customersService.GetCustomerByEmail(Email);
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
		public void UpdateCustomer(string Id, [FromBody] CustomerRequest customerRequest) //Whole object or specific object?
		{

			if (Id.Length != 24)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Id must be 24 Character length";
				errorModel.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

				throw new AppException(JsonConvert.SerializeObject(errorModel));
			}

			customersService.UpdateCustomer(Id, customerRequest);

		}

		//Query Param
		//[HttpGet]
		//public Customer GetCustomerByName([FromQuery] string Name)
		//{

		//	Customer customer = customersService.GetCustomerByName(Name);
		//	if (customer == null)
		//	{
		//		CustomAppError errorModel = new CustomAppError();
		//		errorModel.ErrorMessage = "Data not found";
		//		errorModel.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();

		//		throw new DataNotFoundException(JsonConvert.SerializeObject(errorModel));
		//	}

		//	return customer;

		//}

	}
}
