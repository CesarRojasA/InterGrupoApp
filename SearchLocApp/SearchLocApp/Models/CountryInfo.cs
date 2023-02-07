using Newtonsoft.Json;

namespace SearchLocApp.Models
{
    public class CountryInfo
    {
        [JsonProperty("name")]
        public string NameCountry { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("capital")]
        public string CapitalCountry { get; set; }

        [JsonProperty("independent")]
        public bool Independent { get; set; }
    }

}
