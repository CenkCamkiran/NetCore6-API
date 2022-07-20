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
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.SearchDocument(_ => true);
		}

		public Customer GetCustomerByID(string id)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.SearchDocument(customer => customer.Id == id).SingleOrDefault(); //Null check?
		}

		public Customer GetCustomerByName(string name)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.SearchDocument(customer => customer.Fullname == name).SingleOrDefault(); //Null check?
		}

		public Customer GetCustomerByEmail(string email)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			return mongoDBCommand.SearchDocument(customer => customer.Email == email).SingleOrDefault(); //Null check?
		}

		public void UpdateCustomer(string id, Customer customerRequest)
		{
			MongoDBCommand<Customer> mongoDBCommand = new MongoDBCommand<Customer>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

			mongoDBCommand.ReplaceDocument(customer => customer.Id == id, customerRequest); //Null check?
		}

		public void InsertCustomer(CustomerRequest customerRequest)
		{
			MongoDBCommand<CustomerRequest> mongoDBCommand = new MongoDBCommand<CustomerRequest>(ANALYTICS_DB_NAME, ANALYTICS_COLLECTION_NAME, _mongoClient);

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
