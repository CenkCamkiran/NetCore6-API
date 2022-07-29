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

		private readonly IConnectionMultiplexer _connectionMultiplexer;

		public CustomerCacheRepository(IConnectionMultiplexer connectionMultiplexer)
		{
			_connectionMultiplexer = connectionMultiplexer;
		}

		public List<Customer> GetCustomersCache(string key)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			RedisValue cacheData = redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheData.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(cacheData);

			List<Customer>? customer = JsonConvert.DeserializeObject<List<Customer>>(dataByteArray);

			return customer;

		}

		public void SetCustomersCache(string key, string jsonData, TimeSpan ttl)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			byte[] dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			redisCommand.Add(key, dataByteArray, ttl);
		}

		public Customer GetCustomerByIdCache(string key, string id)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			RedisValue cacheData = redisCommand.Get(key);
			string dataByteArray = "";

			if (!cacheData.IsNullOrEmpty)
				dataByteArray = Encoding.UTF8.GetString(cacheData);

			List<Customer>? customer = JsonConvert.DeserializeObject<List<Customer>>(dataByteArray);
			Customer? customerData = null;

			if (customer != null)
			{
				customerData = customer.Where(customer => customer.id == id).SingleOrDefault();
			}

			return customerData;
		}

		public void SetCustomerByIdCache(string key, string jsonData, TimeSpan ttl)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);
			byte[]? dataByteArray = Encoding.UTF8.GetBytes(jsonData);

			redisCommand.Add(key, dataByteArray, ttl);
		}

		public bool ClearCustomerCache(string key)
		{
			RedisCommand redisCommand = new RedisCommand(_connectionMultiplexer);

			return redisCommand.Remove(key);
		}
	}
}
