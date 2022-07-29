using BusinessLayer.Interfaces;
using DataAccessLayer.MongoDB.Interfaces;
using DataAccessLayer.Redis.Interfaces;
using Models.ControllerModels;
using Models.DataAccessLayerModels;

namespace BusinessLayer
{
	public class CustomersService : ICustomersService
	{

		private ICustomersRepository _customersRepository;
		private ICustomerCacheRepository _customerCacheRepository;

		public CustomersService(ICustomersRepository customersRepository, ICustomerCacheRepository customerCacheRepository)
		{
			_customersRepository = customersRepository;
			_customerCacheRepository = customerCacheRepository;
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

		public void UpdateCustomer(string id, Customer customer)
		{
			_customersRepository.UpdateCustomer(id, customer);
		}

		public void InsertCustomer(CustomerRequest customerRequest)
		{
			_customersRepository.InsertCustomer(customerRequest);
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _customersRepository.GetAllCustomers();
		}

		public Customer GetCustomerByIdCache(string key, string id)
		{
			return _customerCacheRepository.GetCustomerByIdCache(key, id);
		}

		public List<Customer> GetCustomersCache(string key)
		{
			return _customerCacheRepository.GetCustomersCache(key);
		}

		public void SetCustomersCache(string key, string jsonData, TimeSpan ttl)
		{
			_customerCacheRepository.SetCustomersCache(key, jsonData, ttl);
		}

		public bool ClearCustomersCache(string key)
		{
			return _customerCacheRepository.ClearCustomerCache(key);
		}
	}
}
