using System.Net.NetworkInformation;

namespace BusinessLayer.Interfaces
{
	public interface IPingService
	{
		public PingReply PingKeycloak();
		public PingReply PingElasticSearch();
		public PingReply PingMongoDB();
	}
}
