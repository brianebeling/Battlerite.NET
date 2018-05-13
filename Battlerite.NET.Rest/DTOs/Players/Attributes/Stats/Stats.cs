using System;
using System.Collections.Generic;
using Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class Stats
    {
        // TODO NOT IMPLEMENTED
        [Obsolete("This member has not been implemted by Stunlock Studios")]
        public IReadOnlyList<Stackable> Attachements { get; }

        public IReadOnlyList<Character.Character> Characters { get; }

        public int Lost { get; }

        // TODO NOT IMPLEMENTED
        [Obsolete("This member has not been implemted by Stunlock Studios")]
        public IReadOnlyList<Map> Maps { get; }

        public IReadOnlyList<Mode> Modes { get; }

        // TODO NOT IMPLEMENTED
        [Obsolete("This member has not been implemted by Stunlock Studios")]
        public IReadOnlyList<Stackable> Mounts { get; }

        // TODO NOT IMPLEMENTED
        [Obsolete("This member has not been implemted by Stunlock Studios")]
        public IReadOnlyList<Stackable> Outfits { get; }

        public Progress Progress { get; }

        public Rating Rating { get; }

        public IReadOnlyList<ThirdPartyAccount> ThirdPartyAccounts { get; }

        // TODO TimeSpanOffset
        public int TimePlayed { get; }
        // TODO NOT IMPLEMENTED
        [Obsolete("This member has not been implemted by Stunlock Studios")]
        public IReadOnlyList<Stackable> VictoryPoses { get; set; }

        public int Won { get; }

        public Stats(
            IReadOnlyList<Character.Character> characters,
            IReadOnlyList<Mode> modes,
            IReadOnlyList<ThirdPartyAccount> thirdPartyAccounts,
            Progress progress,
            Rating rating,
            int timePlayed,
            int won,
            int lost)
        {
            Characters = characters;
            Modes = modes;
            ThirdPartyAccounts = thirdPartyAccounts;
            Progress = progress;
            Rating = rating;
            TimePlayed = timePlayed;
            Won = won;
            Lost = lost;
        }
    }
}