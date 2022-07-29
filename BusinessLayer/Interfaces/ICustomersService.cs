using Models.ControllerModels;
using Models.DataAccessLayerModels;

namespace BusinessLayer.Interfaces
{
	public interface ICustomersService
	{
		public IEnumerable<Customer> GetAllCustomers();
		public Customer GetCustomerByID(string id);
		public Customer GetCustomerByName(string name);
		public Customer GetCustomerByEmail(string email);
		public void UpdateCustomer(string id, Customer customerRequest);
		public void InsertCustomer(CustomerRequest customerRequest);
		public Customer GetCustomerByIdCache(string key, string id);
		public List<Customer> GetCustomersCache(string key);
		public void SetCustomersCache(string key, string jsonData, TimeSpan ttl);
		public bool ClearCustomersCache(string key);

	}
}
