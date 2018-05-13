using Newtonsoft.Json;

namespace Battlerite.NET.Assets.Stackables
{
    public class Mapping
    {
        [JsonProperty("DevName")]
        public string DevName { get; set; }

        [JsonProperty("EnglishLocalizedName")]
        public string EnglishLocalizedName { get; set; }

        [JsonProperty("Icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("IdRangeName")]
        public IdRangeName IdRangeName { get; set; }

        [JsonProperty("Image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("StackableId")]
        public long StackableId { get; set; }

        [JsonProperty("StackableRangeName")]
        public string StackableRangeName { get; set; }

        [JsonProperty("WideIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string WideIcon { get; set; }
    }
}