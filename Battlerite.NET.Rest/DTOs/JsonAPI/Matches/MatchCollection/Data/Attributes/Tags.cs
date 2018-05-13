using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Attributes
{
    public class Tags
    {
        [JsonProperty("rankingType")]
        public string RankingType { get; set; }

        [JsonProperty("serverType")]
        public string ServerType { get; set; }
    }
}