using System.Collections.Generic;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection
{
    public class Payload
    {
        [JsonProperty("data")]
        public IEnumerable<Data.Data> Data { get; set; }

        [JsonProperty("included")]
        public IEnumerable<Included.Included> Included { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}