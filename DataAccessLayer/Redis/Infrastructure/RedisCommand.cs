using DataAccessLayer.Redis.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Redis.Infrastructure
{
	public class RedisCommand<TModel>: IRedisCommand<TModel>
	{

		private IDatabase redisDatabase;

		public RedisCommand()
		{
			RedisConnection redisConnection = new RedisConnection();
			redisDatabase = redisConnection.connection.GetDatabase();
		}

		public void Add(string key, TModel data)
		{
			string jsonData = JsonConvert.SerializeObject(data);
			redisDatabase.StringSet(key, jsonData);
		}

		public bool Any(string key)
		{
			return redisDatabase.KeyExists(key);
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public TModel Get(string key)
		{
			throw new NotImplementedException();
		}

		public void Remove(string key)
		{
			redisDatabase.KeyDelete(key);
		}
	}
}
