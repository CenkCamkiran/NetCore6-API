using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Net.Mime;
using Models.ControllerModels;

namespace APILayer.Controllers.Queue
{
	[Route("rest/api/v1/main/[controller]")]
	[ApiController]
	public class TestQueueController : ControllerBase
	{
		private ITestQueueService _testQueueService;

		public TestQueueController(ITestQueueService testQueueService)
		{
			_testQueueService = testQueueService;
		}

		[Consumes(MediaTypeNames.Application.Json)]
		[HttpPost]
		public void PublishMessage(TestQueueRequest testQueueRequest)
		{
			_testQueueService.PublishMessage(testQueueRequest.message, testQueueRequest.queue, testQueueRequest.exchange, testQueueRequest.routingKey);
		}

		[HttpGet("Queue/{Queue}")]
		public object? ReceiveMessage(string Queue)
		{
			var cenk = _testQueueService.ConsumeMessage(Queue);

			return null;
		}
	}
}
