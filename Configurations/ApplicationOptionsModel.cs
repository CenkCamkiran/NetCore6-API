﻿using Newtonsoft.Json;

namespace Configurations
{

	public partial class ExternalTools
	{
		[JsonProperty("Keycloak")]
		public Keycloak Keycloak { get; set; }

		[JsonProperty("ElasticSearch")]
		public ElasticSearch ElasticSearch { get; set; }

		[JsonProperty("MongoDB")]
		public MongoDB MongoDB { get; set; }

		[JsonProperty("Redis")]
		public Redis Redis { get; set; }

		[JsonProperty("MSSQL")]
		public MSSQL Mssql { get; set; }

		[JsonProperty("RabbitMQ")]
		public RabbitMQ RabbitMQ { get; set; }

	}

	public partial class MongoDB
	{
		[JsonProperty("Host")]
		public string Host { get; set; }

		[JsonProperty("ConnectionString")]
		public string ConnectionString { get; set; }

		[JsonProperty("DefaultDatabaseName")]
		public string DefaultDatabaseName { get; set; }
	}

	public partial class Redis
	{
		[JsonProperty("Host")]
		public string Host { get; set; }

		[JsonProperty("Password")]
		public string Password { get; set; }

	}

	public partial class RabbitMQ
	{
		[JsonProperty("Host")]
		public string Host { get; set; }

		[JsonProperty("Port")]
		public string Port { get; set; }

		[JsonProperty("Username")]
		public string Username { get; set; }

		[JsonProperty("Password")]
		public string Password { get; set; }	
	}

	public partial class ElasticSearch
	{
		[JsonProperty("Host")]
		public Uri Host { get; set; }

		[JsonProperty("Admin")]
		public Admin Admin { get; set; }

		[JsonProperty("DefaultIndexName")]
		public string DefaultIndexName { get; set; }

	}

	public partial class Admin
	{
		[JsonProperty("Username")]
		public string Username { get; set; }

		[JsonProperty("Password")]
		public string Password { get; set; }

		[JsonProperty("AdminID")]
		public string AdminID { get; set; }
	}

	public partial class Keycloak
	{
		[JsonProperty("Host")]
		public Uri Host { get; set; }

		[JsonProperty("Admin")]
		public Admin Admin { get; set; }

		[JsonProperty("Realms")]
		public Realms Realms { get; set; }

		[JsonProperty("Routes")]
		public Routes Routes { get; set; }
	}

	public partial class Realms
	{
		[JsonProperty("UserRealm")]
		public Realm UserRealm { get; set; }

		[JsonProperty("AdminRealm")]
		public Realm AdminRealm { get; set; }
	}

	public partial class Realm
	{
		[JsonProperty("RealmName")]
		public string RealmName { get; set; }

		[JsonProperty("ClientID")]
		public string ClientId { get; set; }

		[JsonProperty("ClientSecret")]
		public string ClientSecret { get; set; }
	}

	public partial class Routes
	{
		[JsonProperty("TokenRoute")]
		public string TokenRoute { get; set; }

		[JsonProperty("UsersRoute")]
		public string UsersRoute { get; set; }

		[JsonProperty("SessionRoute")]
		public string SessionRoute { get; set; }

		[JsonProperty("IntrospectRoute")]
		public string IntrospectRoute { get; set; }

	}


	public partial class MSSQL
	{
		[JsonProperty("Host")]
		public string Host { get; set; }

		[JsonProperty("Username")]
		public string Username { get; set; }

		[JsonProperty("MSSQLPassword")]
		public string MSSQLPassword { get; set; }

		[JsonProperty("DBName")]
		public string DBName { get; set; }

	}

}
