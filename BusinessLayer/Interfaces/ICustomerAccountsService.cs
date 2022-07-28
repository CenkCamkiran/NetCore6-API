using Models.DataAccessLayerModels;

namespace ServiceLayer.Interfaces
{
	public interface ICustomerAccountsService
	{
		public List<CustomerAccounts> GetCustomerAccountById(string Id);
	}
}
