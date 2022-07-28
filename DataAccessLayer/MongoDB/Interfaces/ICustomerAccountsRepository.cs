using Models.DataAccessLayerModels;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface ICustomerAccountsRepository
	{
		public List<CustomerAccounts> GetCustomerAccountById(string id);
	}
}
