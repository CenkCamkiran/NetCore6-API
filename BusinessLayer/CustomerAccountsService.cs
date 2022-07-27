using DataAccessLayer.MongoDB.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public class CustomerAccountsService : ICustomerAccountsService
	{

		private ICustomerAccountsRepository _customerAccountsRepository;

		public CustomerAccountsService(ICustomerAccountsRepository customerAccountsRepository)
		{
			_customerAccountsRepository = customerAccountsRepository;
		}

		public object GetCustomerAccountById(string Id)
		{
			return _customerAccountsRepository.GetCustomerAccountById(Id);
		}
	}
}
