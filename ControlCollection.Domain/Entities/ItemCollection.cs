using Newtonsoft.Json;

namespace ControlCollection.Domain
{
    public class ItemCollection
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string IdContact { get; set; }


    }
}
