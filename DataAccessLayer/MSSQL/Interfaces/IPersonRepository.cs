using Models.ControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQL.Interfaces
{
	public interface IPersonRepository
	{
		void InsertNewPerson();
		PersonRequest GetPersonById(string Id);
	}
}
