using System.Runtime.Serialization;

namespace Battlerite.NET.Assets.Stackables
{
    public enum IdRangeName
    {
        [EnumMember(Value = "AttachmentEnum")]
        Attachment,

        [EnumMember(Value = "CharacterEnum")]
        Character,

        [EnumMember(Value = "")]
        Empty,

        [EnumMember(Value = "MapEnum")]
        Map,

        [EnumMember(Value = "MountEnum")]
        Mount,

        [EnumMember(Value = "OutfitEnum")]
        Outfit,

        [EnumMember(Value = "VictoryPoseEnum")]
        VictoryPose
    }
}