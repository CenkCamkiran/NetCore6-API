using DataAccessLayer.MSSQL.Interfaces;
using Models.ControllerModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQL.Repository
{
	public class PersonRepository : IPersonRepository
	{
		private readonly IDbConnection _dbConnection;

		public PersonRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public PersonRequest GetPersonById(string Id)
		{
			return null;
		}

		public void InsertNewPerson()
		{
			
		}
	}
}
