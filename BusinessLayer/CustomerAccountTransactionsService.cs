using DataAccessLayer.MongoDB.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public class CustomerAccountTransactionsService : ICustomerAccountTransactionsService
	{

		private ICustomerAccountTransactionsRepository _customerAccountTransactionsRepository;

		public CustomerAccountTransactionsService(ICustomerAccountTransactionsRepository customerAccountTransactionsRepository)
		{
			_customerAccountTransactionsRepository = customerAccountTransactionsRepository;
		}

		public object GetCustomerAccountTransactionsByAccountId(string id)
		{
			return _customerAccountTransactionsRepository.GetCustomerAccountTransactionsByAccountId(id);
		}
	}
}
