using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using ServiceLayer.Interfaces;

namespace ServiceLayer
{
	public class CustomerAccountsService : ICustomerAccountsService
	{

		private ICustomerAccountsRepository _customerAccountsRepository;

		public CustomerAccountsService(ICustomerAccountsRepository customerAccountsRepository)
		{
			_customerAccountsRepository = customerAccountsRepository;
		}

		public List<CustomerAccounts> GetCustomerAccountById(string Id)
		{
			return _customerAccountsRepository.GetCustomerAccountById(Id);
		}
	}
}
