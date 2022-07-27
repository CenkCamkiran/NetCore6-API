using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface ICustomerAccountsRepository
	{
		public object GetCustomerAccountById(string Id);
	}
}
