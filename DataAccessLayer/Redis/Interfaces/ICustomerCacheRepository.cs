using Models.DataAccessLayerModels;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface ICustomerCacheRepository
	{
		public Customer GetCustomerByIdCache(string key, string id);
		public List<Customer> GetCustomersCache(string key);
		public void SetCustomersCache(string key, string jsonData, TimeSpan ttl);
		public bool ClearCustomerCache(string key);
	}
}
