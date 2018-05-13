using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class CharacterBuilder
    {
        public Appereance Appereance { get; set; }
        public CharacterStatsBuilder CharacterStatsBuilder { get; set; }
        public string DeveloperName { get; set; }
        public string EnglishLocilizationName { get; set; }
        public long Id { get; set; }
        public IdRangeName IdRangeName { get; set; }
        public string LocalizedName { get; set; }
        public ModesBuilder Modes { get; set; }
        public ProgressBuilder ProgressBuilder { get; set; }

        public Character Build()
        {
            return new Character(
                DeveloperName,
                EnglishLocilizationName,
                Id,
                IdRangeName,
                LocalizedName,
                Appereance,
                Modes.Build(),
                ProgressBuilder.Build(),
                CharacterStatsBuilder.Build());
        }
    }
}