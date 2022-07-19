using Models.ControllerModels;
using Models.DataAccessLayerModels;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface ICustomersRepository
	{
		public IEnumerable<Customer> GetAllCustomers();
		public Customer GetCustomerByID(string id);
		public Customer GetCustomerByName(string name);
		public Customer GetCustomerByEmail(string email);
		public void UpdateCustomer(string id, Customer customerRequest);
		public void InsertCustomer(CustomerRequest customerRequest);
		public object GetCustomerByUsername(string username);
		public object GetCustomerByBirthDates(string birthdate);
	}
}
