namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class CharacterStats
    {
        public int Deaths { get; }

        public int Kills { get; }

        public int Lost { get; }

        // TODO TimeSpanOffset
        public int TimePlayed { get; }

        public int Won { get; }

        public CharacterStats(int deaths, int kills, int lost, int timePlayed, int won)
        {
            Deaths = deaths;
            Kills = kills;
            Lost = lost;
            TimePlayed = timePlayed;
            Won = won;
        }
    }
}