using DataAccessLayer.RabbitMQ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RabbitMQ.Repository
{
	public class TestQueueRepository : ITestQueueRepository
	{

		private IRabbitMQCommand _rabbitMQCommand;

		public TestQueueRepository(IRabbitMQCommand rabbitMQCommand)
		{
			_rabbitMQCommand = rabbitMQCommand;
		}

		public object ConsumeMessage(string queue)
		{
			return _rabbitMQCommand.ConsumeMessage(queue);
		}

		public void PublishMessage(string message, string queue, string exchange, string routingKey)
		{
			_rabbitMQCommand.PublishMessage(message, queue, exchange, routingKey);	
		}
	}
}
