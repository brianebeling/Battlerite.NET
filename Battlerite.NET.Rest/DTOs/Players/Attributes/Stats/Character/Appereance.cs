namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class Appereance
    {
        public string Icon { get; }
        public string WideIcon { get; }

        public Appereance(string icon, string wideIcon)
        {
            Icon = icon;
            WideIcon = wideIcon;
        }
    }
}