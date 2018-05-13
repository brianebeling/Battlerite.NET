using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class ThidPartyAccountsBuilder
    {
        public IDictionary<string, ThirdPartyAccountBuilder> ThirdPartyAccountBuilders { get; }

        public ThidPartyAccountsBuilder(IDictionary<string, ThirdPartyAccountBuilder> thirdPartyAccountBuilders)
        {
            ThirdPartyAccountBuilders = thirdPartyAccountBuilders;
        }

        public IReadOnlyList<ThirdPartyAccount> Build()
        {
            return ThirdPartyAccountBuilders.Select(x => x.Value.Build()).ToImmutableList();
        }
    }
}