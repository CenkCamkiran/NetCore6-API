﻿using BusinessLayer.Interfaces;
using DataAccessLayer.MongoDB.Repository;
using Models.ControllerModels;
using Models.DataAccessLayerModels;

namespace BusinessLayer
{
	public class CustomersService : ICustomersService
	{

		private CustomersRepository<Customer> customersRepository;

		public CustomersService()
		{
			customersRepository = new CustomersRepository<Customer>();
		}

		public Customer GetCustomerByEmail(string email)
		{
			return customersRepository.GetCustomerByEmail(email);
		}

		public Customer GetCustomerByID(string id)
		{
			return customersRepository.GetCustomerByID(id);
		}

		public Customer GetCustomerByName(string name)
		{
			return customersRepository.GetCustomerByName(name);
		}

		public void UpdateCustomer(string id, CustomerRequest customerRequest)
		{
			customersRepository.UpdateCustomer(id, customerRequest);
		}
	}
}
