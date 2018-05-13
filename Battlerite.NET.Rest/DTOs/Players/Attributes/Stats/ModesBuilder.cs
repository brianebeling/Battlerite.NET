using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class ModesBuilder
    {
        public IDictionary<string, ModeBuilder> ModeBuilders { get; }

        public ModesBuilder(IDictionary<string, ModeBuilder> modeBuilders)
        {
            ModeBuilders = modeBuilders;
        }

        public IReadOnlyList<Mode> Build()
        {
            return ModeBuilders.Select(x => x.Value.Build()).ToImmutableList();
        }
    }
}