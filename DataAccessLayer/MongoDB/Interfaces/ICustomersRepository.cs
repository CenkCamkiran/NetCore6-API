﻿using Models.ControllerModels;
using Models.DataAccessLayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface ICustomersRepository
	{
		public Customer GetCustomerByID(string id);
		public Customer GetCustomerByName(string name);
		public Customer GetCustomerByEmail(string email);
		public void UpdateCustomer(string id, CustomerRequest customerRequest);
		public object GetCustomerByUsername(string username);	
		public object GetCustomerByBirthDates(string birthdate);	
		public IEnumerable<Customer> GetAllCustomers(string email);	
	}
}
