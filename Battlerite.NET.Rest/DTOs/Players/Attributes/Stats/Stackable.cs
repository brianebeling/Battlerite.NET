using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class Stackable
    {
        public string DeveloperName { get; }

        public string EnglishLocalizedName { get; }

        public long Id { get; }

        public IdRangeName IdRangeName { get; }
        public string LocalizedName { get; }

        public Stackable(
            string developerName,
            string englishLocalizedName,
            long id,
            IdRangeName idRangeName,
            string localizedName)
        {
            DeveloperName = developerName;
            EnglishLocalizedName = englishLocalizedName;
            Id = id;
            IdRangeName = idRangeName;
            LocalizedName = localizedName;
        }
    }
}