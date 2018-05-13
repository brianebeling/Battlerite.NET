using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class CharactersBuilder
    {
        public IDictionary<string, CharacterBuilder> CharacterBuilders { get; }

        public CharactersBuilder(IDictionary<string, CharacterBuilder> characterBuilders)
        {
            CharacterBuilders = characterBuilders;
        }

        public IReadOnlyList<Character> Build()
        {
            return CharacterBuilders.Select(x => x.Value.Build()).ToImmutableList();
        }
    }
}