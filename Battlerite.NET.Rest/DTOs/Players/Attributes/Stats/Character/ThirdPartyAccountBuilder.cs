namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class ThirdPartyAccountBuilder
    {
        public string Name { get; set; }

        public ThirdPartyAccount Build()
        {
            return new ThirdPartyAccount(Name);
        }
    }
}