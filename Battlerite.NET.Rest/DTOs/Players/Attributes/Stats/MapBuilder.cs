using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class MapBuilder
    {
        public string DeveloperName { get; set; }
        public string EnglishLocilizationName { get; set; }
        public long Id { get; set; }
        public IdRangeName IdRangeName { get; set; }

        public string Image { get; set; }

        public string LocalizedName { get; set; }

        public int Lost { get; set; }
        public int Won { get; set; }

        public Map Build()
        {
            return new Map(DeveloperName, EnglishLocilizationName, Id, IdRangeName, LocalizedName, Image, Lost, Won);
        }
    }
}