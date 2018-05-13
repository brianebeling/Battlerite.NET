using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Included
{
    public class Player
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}