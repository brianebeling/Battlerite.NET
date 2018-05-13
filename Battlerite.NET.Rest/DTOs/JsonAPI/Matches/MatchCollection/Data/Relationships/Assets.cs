using System.Collections.Generic;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Relationships
{
    public class Assets
    {
        [JsonProperty("data")]
        public IEnumerable<Included.Data> Data { get; set; }
    }
}