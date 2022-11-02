using Configurations;
using DataAccessLayer.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RabbitMQ.Infrastructure
{
	public class RabbitMQCommand: IRabbitMQCommand
	{
		private readonly IConnection _connection;

		public RabbitMQCommand(IConnection connection)
		{
			_connection = connection;
		}

		public void PublishMessage(string message, string queue, string exchange, string routingKey)
		{
			try
			{
				using (var channel = _connection.CreateModel())
				{
					channel.QueueDeclare(
						queue: queue,
						durable: false,
						autoDelete: false,
						exclusive: false,
						arguments: null
					);

					byte[]? body = Encoding.UTF8.GetBytes(message);

					channel.BasicPublish(
						exchange: exchange,
						routingKey: routingKey,
						body: body,
						basicProperties: null);
				}
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public object ConsumeMessage(string queue)
		{

			try
			{
				using (var channel = _connection.CreateModel())
				{
					string message = "";

					channel.QueueDeclare(
						queue: queue,
						durable: false,
						autoDelete: false,
						exclusive: false,
						arguments: null
					);

					var consumer = new EventingBasicConsumer(channel);
					consumer.Received += (model, ea) =>
					{
						byte[]? body = ea.Body.ToArray();
						message = Encoding.UTF8.GetString(body);
					};

					channel.BasicConsume(queue: queue,
										 autoAck: true,
										 consumer: consumer);

					return message;
				}
			}
			catch (Exception ex)
			{
				throw new Exception();
			}

		}
	}

}
