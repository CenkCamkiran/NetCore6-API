﻿using Models.ControllerModels;
using Models.DataAccessLayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface ICustomersService
	{
		public Customer GetCustomerByID(string id);

		public Customer GetCustomerByName(string name);

		public Customer GetCustomerByEmail(string email);

		public void UpdateCustomer(string id, CustomerRequest customerRequest);
	}
}
