using System;
using System.Collections.Generic;

using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models.DataAccessLayerModels
{

	public class CustomerAccountTransactions
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; }

		[BsonElement("username")]
		[BsonRepresentation(BsonType.String)]
		public string username { get; set; }

		[BsonElement("name")]
		[BsonRepresentation(BsonType.String)]
		public string name { get; set; }

		[BsonElement("address")]
		[BsonRepresentation(BsonType.String)]
		public string address { get; set; }

		[BsonElement("birthdate")]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime birthdate { get; set; }

		[BsonElement("email")]
		[BsonRepresentation(BsonType.String)]
		public string email { get; set; }

		[BsonElement("active")]
		[BsonRepresentation(BsonType.Boolean)]
		public bool active { get; set; }

		[BsonElement("tier_and_details")]
		public Dictionary<string, TierAndDetail>? tierAndDetails { get; set; }

		[BsonElement("account_details")]
		public AccountDetail[] accountDetails { get; set; }
	}

	public enum Symbol { Amd, Crm, Csco, Intc, Nvda };

	public enum TransactionCode { Buy, Sell };

	internal static class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				SymbolConverter.Singleton,
				TransactionCodeConverter.Singleton,
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}

	internal class SymbolConverter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(Symbol) || t == typeof(Symbol?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			switch (value)
			{
				case "amd":
					return Symbol.Amd;
				case "crm":
					return Symbol.Crm;
				case "csco":
					return Symbol.Csco;
				case "intc":
					return Symbol.Intc;
				case "nvda":
					return Symbol.Nvda;
			}
			throw new Exception("Cannot unmarshal type Symbol");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}
			var value = (Symbol)untypedValue;
			switch (value)
			{
				case Symbol.Amd:
					serializer.Serialize(writer, "amd");
					return;
				case Symbol.Crm:
					serializer.Serialize(writer, "crm");
					return;
				case Symbol.Csco:
					serializer.Serialize(writer, "csco");
					return;
				case Symbol.Intc:
					serializer.Serialize(writer, "intc");
					return;
				case Symbol.Nvda:
					serializer.Serialize(writer, "nvda");
					return;
			}
			throw new Exception("Cannot marshal type Symbol");
		}

		public static readonly SymbolConverter Singleton = new SymbolConverter();
	}

	internal class TransactionCodeConverter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(TransactionCode) || t == typeof(TransactionCode?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			switch (value)
			{
				case "buy":
					return TransactionCode.Buy;
				case "sell":
					return TransactionCode.Sell;
			}
			throw new Exception("Cannot unmarshal type TransactionCode");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}
			var value = (TransactionCode)untypedValue;
			switch (value)
			{
				case TransactionCode.Buy:
					serializer.Serialize(writer, "buy");
					return;
				case TransactionCode.Sell:
					serializer.Serialize(writer, "sell");
					return;
			}
			throw new Exception("Cannot marshal type TransactionCode");
		}

		public static readonly TransactionCodeConverter Singleton = new TransactionCodeConverter();
	}
}
