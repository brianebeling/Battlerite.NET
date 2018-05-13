using System.Runtime.Serialization;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public enum Region
    {
        [EnumMember(Value = "eu")]
        Europe,

        [EnumMember(Value = "oce")]
        Oceania,

        [EnumMember(Value = "na")]
        NorthAmerica,

        [EnumMember(Value = "south_america")]
        SouthAmerica,

        [EnumMember(Value = "asia")]
        Asia
    }
}