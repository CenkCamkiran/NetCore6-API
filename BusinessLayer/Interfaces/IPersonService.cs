using Models.ControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IPersonService
	{
		void InsertNewPerson(PersonRequest personData);
		PersonRequest GetPersonById(string Id);
	}
}
