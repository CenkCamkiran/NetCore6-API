using DataAccessLayer.Redis.Infrastructure;
using DataAccessLayer.Redis.Interfaces;
using Models.DataAccessLayerModels;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace DataAccessLayer.Redis.Repository
{
	public class CustomerCacheRepository : ICustomerCacheRepository
	{

		private IRedisCommand _redisCommand;

		public CustomerCacheRepository(IRedisCommand redisCommand)
		{
			_redisCommand = redisCommand;
		}

		public List<Customer> GetCustomersCache(string key)
		{
			RedisValue cacheData = _redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheData.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(cacheData);

			List<Customer>? customer = JsonConvert.DeserializeObject<List<Customer>>(dataByteArray);

			return customer;

		}

		public void SetCustomersCache(string key, string jsonData, TimeSpan ttl)
		{
			byte[] dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			_redisCommand.Add(key, dataByteArray, ttl);
		}

		public Customer GetCustomerByIdCache(string key, string id)
		{
			RedisValue cacheData = _redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheData.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(cacheData);

			List<Customer>? customer = JsonConvert.DeserializeObject<List<Customer>>(dataByteArray);
			Customer? customerData = null;

			if (customer != null)
				customerData = customer.Where(customer => customer.id == id).SingleOrDefault();

			return customerData;
		}

		public void SetCustomerByIdCache(string key, string jsonData, TimeSpan ttl)
		{
			byte[]? dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			_redisCommand.Add(key, dataByteArray, ttl);
		}

		public bool ClearCustomerCache(string key)
		{

			return _redisCommand.Remove(key);
		}
	}
}
