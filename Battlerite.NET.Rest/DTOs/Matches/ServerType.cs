using System.Runtime.Serialization;

namespace Battlerite.NET.Rest.DTOs.Matches
{
    public enum ServerType
    {
        [EnumMember(Value = "QUICK2V2")]
        Quick2V2,

        [EnumMember(Value = "QUICK3V3")]
        Quick3V3,

        [EnumMember(Value = "PRIVATE")]
        Private
    }
}