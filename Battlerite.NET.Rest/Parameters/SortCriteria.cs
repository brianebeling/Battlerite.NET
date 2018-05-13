using System.Runtime.Serialization;

namespace Battlerite.NET.Rest.Parameters
{
    // TODO Research
    public enum SortCriteria
    {
        [EnumMember(Value = "createdAt")]
        CreatedAt,

        [EnumMember(Value = "duration")]
        Duration
    }
}