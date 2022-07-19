namespace Models.ControllerModels
{
    public class Child
    {
        public string kind { get; set; }

        public Data data { get; set; }
    }

    public class Data
    {
        public string subReddit { get; set; }

        public string authorFullname { get; set; }

        public string title { get; set; }

        public int created { get; set; }

        public int ups { get; set; }
    }

    public class Posts
    {
        public string after { get; set; }

        public int dist { get; set; }

        public string modhash { get; set; }

        public string geoFilter { get; set; }

        public List<Child> children { get; set; }
    }
}
