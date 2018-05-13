using System;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Converters
{
    public class StringToIntConverter : JsonConverter<int>
    {
        public override int ReadJson(
            JsonReader reader,
            Type objectType,
            int existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return int.TryParse(reader.Value.ToString(), out var value) ? value : 0;
        }

        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}