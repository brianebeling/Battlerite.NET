namespace Battlerite.NET.Rest.Parameters
{
    internal struct Parameter : IParameter
    {
        public Parameter(string keyword, string value)
        {
            Keyword = keyword;
            Value = value;
        }

        public string Keyword { get; set; }

        public string Value { get; set; }

        public string Get()
        {
            return $"{Keyword}={Value}";
        }
    }
}