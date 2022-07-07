﻿using Entities.HelpersEntities;
using Nest;

namespace DataAccessLayer.ElasticSearch.Infrastructure
{
	public partial class ElasticSearchConnection
	{
		private AppConfigurationHelper appConfigurationHelper;
		private readonly ConnectionSettings connection;

		private ElasticClient client;
		public ElasticClient ElasticSearchClient { get => client; }
	}
}