using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface ICustomerAccountTransactionsRepository
	{
		public object GetCustomerAccountTransactionsByAccountId(string id);
	}
}
