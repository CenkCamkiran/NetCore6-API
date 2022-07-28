using DataAccessLayer.MongoDB.Interfaces;
using Models.DataAccessLayerModels;
using ServiceLayer.Interfaces;

namespace ServiceLayer
{
	public class CustomerAccountTransactionsService : ICustomerAccountTransactionsService
	{

		private ICustomerAccountTransactionsRepository _customerAccountTransactionsRepository;

		public CustomerAccountTransactionsService(ICustomerAccountTransactionsRepository customerAccountTransactionsRepository)
		{
			_customerAccountTransactionsRepository = customerAccountTransactionsRepository;
		}

		public List<CustomerAccountTransactions> GetCustomerAccountTransactionsByAccountId(string id)
		{
			return _customerAccountTransactionsRepository.GetCustomerAccountTransactionsByAccountId(id);
		}
	}
}
