namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class ProgressBuilder
    {
        public int Experience { get; set; }
        public int Level { get; set; }

        public Progress Build()
        {
            return new Progress(Experience, Level);
        }
    }
}