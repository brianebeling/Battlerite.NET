using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class PlacementGames
    {
        [JsonProperty("placementGamesLeft")]
        public int Remaining { get; private set; }
    }
}