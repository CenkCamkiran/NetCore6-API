using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;
using ServiceLayer.Interfaces;

namespace APILayer.Controllers.Test
{
	[Route("rest/api/v1/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet]	
		public TestRequest TestingAsyncOps()
		{
			return new TestRequest()
			{
				Message = "Testing..."
			};
		}
	}
}
