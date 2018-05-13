using System;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs
{
    public class Links
    {
        /// <summary>
        ///     Gets or sets the schema. NOT IMPLEMENTED: The schema seems to be always empty.
        /// </summary>
        /// <value>
        ///     The schema.
        /// </value>
        [Obsolete("Not implemented by Stunlock Studios yet.")]
        [JsonProperty("schema")]
        public string Schema { get; private set; }

        [JsonProperty("self")]
        public string Self { get; private set; }
    }
}