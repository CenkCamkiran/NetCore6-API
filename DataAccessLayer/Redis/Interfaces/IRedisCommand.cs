using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Redis.Interfaces
{
	public interface IRedisCommand<TModel>
	{
		public void Add(string key, TModel data);
		public TModel Get(string key);
		public void Remove(string key);
		public bool Any(string key);
		public void Clear();
	}
}
