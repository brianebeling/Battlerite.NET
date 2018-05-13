using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches
{
    public class Tags
    {
        [JsonProperty("rankingType")]
        public RankingType RankingType { get; set; }

        [JsonProperty("serverType")]
        public ServerType ServerType { get; set; }
    }
}