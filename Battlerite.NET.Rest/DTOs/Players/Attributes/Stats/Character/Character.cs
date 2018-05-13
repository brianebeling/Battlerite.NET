using System.Collections.Generic;
using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character
{
    public class Character : Stackable
    {
        public Appereance Appereance { get; }

        public IReadOnlyList<Mode> Modes { get; }

        public Progress Progress { get; }

        public CharacterStats Stats { get; }

        public Character(
            string developerName,
            string englishLocalizedName,
            long id,
            IdRangeName idRangeName,
            string localizedName,
            Appereance appereance,
            IReadOnlyList<Mode> modes,
            Progress progress,
            CharacterStats stats) : base(developerName, englishLocalizedName, id, idRangeName, localizedName)
        {
            Appereance = appereance;
            Modes = modes;
            Progress = progress;
            Stats = stats;
        }
    }
}