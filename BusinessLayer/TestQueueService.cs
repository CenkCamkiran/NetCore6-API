using DataAccessLayer.RabbitMQ.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public class TestQueueService : ITestQueueService
	{

		private ITestQueueRepository _testQueueRepository;

		public TestQueueService(ITestQueueRepository testQueueRepository)
		{
			_testQueueRepository = testQueueRepository;
		}

		public object ConsumeMessage(string queue)
		{
			return _testQueueRepository.ConsumeMessage(queue);
		}

		public void PublishMessage(string message, string queue, string exchange, string routingKey)
		{
			_testQueueRepository.PublishMessage(message, queue, exchange, routingKey);
		}
	}
}
