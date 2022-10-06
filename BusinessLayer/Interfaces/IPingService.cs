using System.Net.NetworkInformation;

namespace ServiceLayer.Interfaces
{
	public interface IPingService
	{
		public PingReply PingKeycloak();
		public PingReply PingElasticSearch();
		public PingReply PingMongoDB();
		public PingReply PingRedis();
		public PingReply PingRabbitMQ();
	}
}
