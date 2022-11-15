using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ControllerModels;

namespace APILayer.Controllers.Test
{
	[Route("api/[controller]")]
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
