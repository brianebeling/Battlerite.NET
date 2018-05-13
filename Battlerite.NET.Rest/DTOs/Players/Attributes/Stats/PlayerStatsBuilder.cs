using Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class PlayerStatsBuilder
    {
        public CharactersBuilder CharactersBuilder { get; set; }

        public int Lost { get; set; }

        public ModesBuilder ModesBuilder { get; set; }

        public ProgressBuilder ProgressBuilder { get; set; }

        public RatingBuilder RatingBuilder { get; set; }

        public ThidPartyAccountsBuilder ThirdPartyAccountsBuilder { get; set; }

        public int TimePlayed { get; set; }

        public int Won { get; set; }

        public Stats Build()
        {
            return new Stats(
                CharactersBuilder.Build(),
                ModesBuilder.Build(),
                ThirdPartyAccountsBuilder.Build(),
                ProgressBuilder.Build(),
                RatingBuilder.Build(),
                TimePlayed,
                Won,
                Lost);
        }
    }
}