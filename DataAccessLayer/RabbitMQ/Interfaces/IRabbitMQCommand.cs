using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RabbitMQ.Interfaces
{
	public interface IRabbitMQCommand
	{
		public void PublishMessage(string message, string queue, string exchange, string routingKey);
		public object ConsumeMessage(string queue);

	}
}
