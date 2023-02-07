using Newtonsoft.Json;
using SQLite;

namespace SearchLocApp.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [JsonProperty("country_name")]
        public string Country_name { get; set; }

        [JsonProperty("country_short_name")]
        public string Country_short_name { get; set; }

        [JsonProperty("country_phone_code")]
        public int Country_phone_code { get; set; }

        public string Capital { get; set; }
        public string Region { get; set; }
    }

}
