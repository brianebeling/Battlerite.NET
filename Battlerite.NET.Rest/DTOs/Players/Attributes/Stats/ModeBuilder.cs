namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class ModeBuilder
    {
        public int Lost { get; set; }

        public string Name { get; set; }

        public int Won { get; set; }

        public Mode Build()
        {
            return new Mode(Lost, Name, Won);
        }
    }
}