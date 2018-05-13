namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class CharacterStatsBuilder
    {
        public int Deaths { get; set; }

        public int Kills { get; set; }

        public int Lost { get; set; }

        public int TimePlayed { get; set; }

        public int Won { get; set; }

        public CharacterStats Build()
        {
            return new CharacterStats(Deaths, Kills, Lost, TimePlayed, Won);
        }
    }
}