using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using ServiceLayer.Interfaces;
using System.Net.Mime;

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

		[HttpGet("Id/{Id}")]
		public PersonRequest GetPersonById(string Id)
		{
			return _personService.GetPersonById(Id);
		}

		[Consumes(MediaTypeNames.Application.Json)]
		[HttpPut]
		public NoContentResult GetPersonById(PersonRequest personRequest)
		{
			_personService.InsertNewPerson(personRequest);

			return NoContent();
		}

	}
}
