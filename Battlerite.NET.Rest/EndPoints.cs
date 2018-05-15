namespace Battlerite.NET.Rest
{
    public static class EndPoints
    {
        public const string BaseUrl = "https://api.developer.battlerite.com/shards/global";

        public const string Matches = "/matches";

        public const string Players = "/players";

        public const string SingleMatch = Matches + "/";

        public const string SinglePlayer = Players + "/";
    }
}