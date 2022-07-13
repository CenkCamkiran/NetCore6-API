using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Models.ControllerModels
{
	public class CustomerRequest
	{
        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public int[] Accounts { get; set; }

        public Dictionary<string, TierAndDetail>? TierAndDetails { get; set; }
    }

    public partial class TierAndDetail
    {

        public string Tier { get; set; }

        public string Id { get; set; }

        public bool Active { get; set; }

        public string[] Benefits { get; set; }
    }
}
