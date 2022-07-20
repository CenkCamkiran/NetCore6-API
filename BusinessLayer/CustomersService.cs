using BusinessLayer.Interfaces;
using DataAccessLayer.MongoDB.Interfaces;
using Models.ControllerModels;
using Models.DataAccessLayerModels;

namespace BusinessLayer
{
	public class CustomersService : ICustomersService
	{

		private ICustomersRepository _customersRepository;

		public CustomersService(ICustomersRepository customersRepository)
		{
			_customersRepository = customersRepository;
		}

		public Customer GetCustomerByEmail(string email)
		{
			return _customersRepository.GetCustomerByEmail(email);
		}

		public Customer GetCustomerByID(string id)
		{
			return _customersRepository.GetCustomerByID(id);
		}

		public Customer GetCustomerByName(string name)
		{
			return _customersRepository.GetCustomerByName(name);
		}

		public void UpdateCustomer(string id, Customer customerRequest)
		{
			_customersRepository.UpdateCustomer(id, customerRequest);
		}

		public void InsertCustomer(CustomerRequest customerRequest)
		{
			_customersRepository.InsertCustomer(customerRequest);
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _customersRepository.GetAllCustomers();
		}
	}
}
