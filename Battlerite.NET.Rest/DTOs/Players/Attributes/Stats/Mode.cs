namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class Mode
    {
        public int Lost { get; }
        public string Name { get; }

        public int Won { get; }

        public Mode(int lost, string name, int won)
        {
            Lost = lost;
            Name = name;
            Won = won;
        }
    }
}