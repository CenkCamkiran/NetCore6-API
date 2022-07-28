using DataAccessLayer.MongoDB.Infrastructure;
using DataAccessLayer.MongoDB.Interfaces;
using Models.ControllerModels;
using Models.DataAccessLayerModels;
using MongoDB.Driver;

namespace DataAccessLayer.MongoDB.Repository
{
	public class CustomersRepository : ICustomersRepository
	{

		private const string ANALYTICS_DB_NAME = "analytics";
		private const string ANALYTICS_COLLECTION_NAME = "customers";

		private readonly IMongoClient _mongoClient;

		public CustomersRepository(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			MongoDBCommand<Customer, object> mongoDBCommand = new MongoDBCommand<Customer, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.SearchDocument(_ => true);
		}

		public Customer GetCustomerByID(string id)
		{
			MongoDBCommand<Customer, object> mongoDBCommand = new MongoDBCommand<Customer, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			IEnumerable<Customer>? result = mongoDBCommand.SearchDocument(customer => customer.id == id);

			return result.SingleOrDefault();

		}

		public Customer GetCustomerByName(string name)
		{
			MongoDBCommand<Customer, object> mongoDBCommand = new MongoDBCommand<Customer, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			IEnumerable<Customer> result = mongoDBCommand.SearchDocument(customer => customer.fullname == name);

			return result.SingleOrDefault();
		}

		public Customer GetCustomerByEmail(string email)
		{
			MongoDBCommand<Customer, object> mongoDBCommand = new MongoDBCommand<Customer, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			IEnumerable<Customer> result = mongoDBCommand.SearchDocument(customer => customer.email == email);

			return result.SingleOrDefault();
		}

		public void UpdateCustomer(string id, Customer customer)
		{
			MongoDBCommand<Customer, object> mongoDBCommand = new MongoDBCommand<Customer, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			mongoDBCommand.ReplaceDocument(customer => customer.id == id, customer); //Null check?
		}

		public void InsertCustomer(CustomerRequest customerRequest)
		{
			MongoDBCommand<CustomerRequest, object> mongoDBCommand = new MongoDBCommand<CustomerRequest, object>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			mongoDBCommand.InsertDocument(customerRequest); //Null check?
		}

		public object GetCustomerByBirthDates(string birthdate)
		{
			return null;
		}

		public object GetCustomerByUsername(string username)
		{
			return null;
		}

	}
}
