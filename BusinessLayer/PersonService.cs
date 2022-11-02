using DataAccessLayer.MSSQL.Interfaces;
using Models.ControllerModels;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public class PersonService : IPersonService
	{

		private IPersonRepository _personRepository;

		public PersonService(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public PersonRequest GetPersonById(string Id)
		{
			return _personRepository.GetPersonById(Id);
		}

		public void InsertNewPerson(PersonRequest personData)
		{
			_personRepository.InsertNewPerson(personData);
		}
	}
}
