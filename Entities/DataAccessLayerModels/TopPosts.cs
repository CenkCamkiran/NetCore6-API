using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.DataAccessLayerModels
{
	public class Child
	{
		[BsonElement("kind")]
		[BsonRepresentation(BsonType.String)]
		public string kind { get; set; }

		[BsonElement("data")]
		public Data data { get; set; }
	}

	public class Data
	{
		[BsonElement("subreddit")]
		[BsonRepresentation(BsonType.String)]
		public string subReddit { get; set; }

		[BsonElement("author_fullname")]
		[BsonRepresentation(BsonType.String)]
		public string authorFullname { get; set; }

		[BsonElement("title")]
		[BsonRepresentation(BsonType.String)]
		public string title { get; set; }

		[BsonElement("created")]
		[BsonRepresentation(BsonType.Int32)]
		public int created { get; set; }

		[BsonElement("ups")]
		[BsonRepresentation(BsonType.Int32)]
		public int ups { get; set; }
	}

	public class Posts
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("after")]
		[BsonRepresentation(BsonType.String)]
		public string after { get; set; }

		[BsonElement("dist")]
		[BsonRepresentation(BsonType.Int32)]
		public int dist { get; set; }

		[BsonElement("modhash")]
		[BsonRepresentation(BsonType.String)]
		public string modhash { get; set; }

		[BsonElement("geo_filter")]
		[BsonRepresentation(BsonType.String)]
		public string geoFilter { get; set; }

		[BsonElement("children")]
		public List<Child> children { get; set; }
	}
}
