using Models.DataAccessLayerModels;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface ICustomerAccountTransactionsRepository
	{
		public List<CustomerAccountTransactions> GetCustomerAccountTransactionsByAccountId(string id);
	}
}
