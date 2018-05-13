using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class Map : Stackable
    {
        public string Image { get; }

        public int Lost { get; }

        public int Won { get; }

        public Map(
            string developerName,
            string englishLocalizedName,
            long id,
            IdRangeName idRangeName,
            string localizedName,
            string image,
            int lost,
            int won) : base(
            developerName,
            englishLocalizedName,
            id,
            idRangeName,
            localizedName)
        {
            Image = image;
            Lost = lost;
            Won = won;
        }
    }
}