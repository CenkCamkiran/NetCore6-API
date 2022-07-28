using Models.DataAccessLayerModels;

namespace ServiceLayer.Interfaces
{
	public interface ICustomerAccountTransactionsService
	{
		public List<CustomerAccountTransactions> GetCustomerAccountTransactionsByAccountId(string id);
	}
}
