using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.ControllerModels;
using Models.DataAccessLayerModels;

namespace DataAccessLayer.MongoDB.Repository
{
	public class CustomersRepository<TModel> : ICustomersRepository where TModel : class
	{

		private const string ANALYTICS_DB_NAME = "analytics";
		private const string ANALYTICS_COLLECTION_NAME = "customers";

		public Customer GetCustomerByID(string id)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME);

			return mongoDBCommand.SearchDocument(customer => customer.Id == id).SingleOrDefault(); //Null check?
		}

		public Customer GetCustomerByName(string name)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME);

			return mongoDBCommand.SearchDocument(customer => customer.Fullname == name).SingleOrDefault(); //Null check?
		}

		public Customer GetCustomerByEmail(string email)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME);

			return mongoDBCommand.SearchDocument(customer => customer.Email == email).SingleOrDefault(); //Null check?
		}

		public void UpdateCustomer(string id, CustomerRequest customerRequest)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME);

			mongoDBCommand.UpdateDocument(id, customer => customer.Id == id); //Null check?
		}

		public object GetCustomerByBirthDates(string birthdate)
		{
			return null;
		}

		public object GetCustomerByUsername(string username)
		{
			return null;
		}

		public IEnumerable<Customer> GetAllCustomers(string email)
		{
			return null;
		}

	}
}
