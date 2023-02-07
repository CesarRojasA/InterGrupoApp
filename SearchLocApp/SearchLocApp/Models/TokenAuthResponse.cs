using Newtonsoft.Json;

namespace SearchLocApp.Models
{
    public class TokenAuthResponse
    {
        [JsonProperty("auth_token")]
        public string Auth_token { get; set; }
    }
}
