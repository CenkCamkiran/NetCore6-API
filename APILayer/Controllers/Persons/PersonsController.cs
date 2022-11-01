using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using ServiceLayer.Interfaces;

namespace APILayer.Controllers.Persons
{
	[Route("rest/api/v1/main/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private IPersonService _personService;

		public PersonsController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpGet("/Id/{Id}")]
		public PersonRequest GetPersonById(string Id)
		{
			_personService.GetPersonById(Id);

			return topPosts;
		}

	}
}
