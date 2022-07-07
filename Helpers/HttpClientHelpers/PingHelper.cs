﻿using Entities.HelpersEntities;
using System.Net.NetworkInformation;

namespace Helpers.HttpClientHelper
{
	public class PingHelper : AppConfigurationHelper
	{

		public PingHelper()
		{
		}

		public PingReply PingKeycloak(string KeycloakHost)
		{

			Ping ping = new Ping();

			Task<PingReply> pingResult = ping.SendPingAsync(KeycloakHost, 15);

			return pingResult.Result;
		}

		public PingReply PingElasticsearch(string ElasticsearchHost)
		{

			Ping ping = new Ping();

			Task<PingReply> pingResult = ping.SendPingAsync(ElasticsearchHost, 15);

			return pingResult.Result;
		}

		//......

	}
}