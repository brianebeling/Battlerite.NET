namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class Progress
    {
        public int Experience { get; }
        public int Level { get; }

        public Progress(int experience, int level)
        {
            Experience = experience;
            Level = level;
        }
    }
}