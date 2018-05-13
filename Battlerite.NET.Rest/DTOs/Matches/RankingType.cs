using System;
using System.Runtime.Serialization;

namespace Battlerite.NET.Rest.DTOs.Matches
{
    [Flags]
    public enum RankingType
    {
        [EnumMember(Value = "NONE")]
        None,

        [EnumMember(Value = "UNRANKED")]
        Unranked,

        [EnumMember(Value = "RANKED")]
        Ranked
    }
}