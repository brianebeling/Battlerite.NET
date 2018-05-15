using System;
using System.Collections.Generic;
using Battlerite.NET.Assets.Stackables;
using Battlerite.NET.Rest.DTOs.Players.Attributes;
using Battlerite.NET.Rest.DTOs.Players.Attributes.Stats;
using Battlerite.NET.Rest.DTOs.Players.Attributes.Stats.Character;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Battlerite.NET.Rest.Converters
{
    public class PopulatedAttributesJsonConverter : JsonConverter<PopulatedAttributes>
    {
        private readonly IReadOnlyDictionary<long, Mapping> mappings;

        public PopulatedAttributesJsonConverter(IReadOnlyDictionary<long, Mapping> mappings)
        {
            this.mappings = mappings;
        }

        public override PopulatedAttributes ReadJson(
            JsonReader reader,
            Type objectType,
            PopulatedAttributes existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var stats = jObject["stats"];


            var playerStatsBuilder =
                new PlayerStatsBuilder
                {
                    CharactersBuilder = new CharactersBuilder(new Dictionary<string, CharacterBuilder>()),
                    ModesBuilder = new ModesBuilder(new Dictionary<string, ModeBuilder>()),
                    ProgressBuilder = new ProgressBuilder(),
                    RatingBuilder = new RatingBuilder(),
                    ThirdPartyAccountsBuilder =
                        new ThidPartyAccountsBuilder(new Dictionary<string, ThirdPartyAccountBuilder>())
                };


            foreach (var stat in stats.Children<JProperty>())
                if (long.TryParse(stat.Name, out var key))
                {
                    if (!mappings.TryGetValue(key, out var mapping))
                        continue;

                    var value = stat.Value.ToObject<int>();

                    switch (mapping.IdRangeName)
                    {
                        case IdRangeName.Attachment:
                            throw new NotImplementedException();

                        case IdRangeName.Character:

                            if (!playerStatsBuilder.CharactersBuilder.CharacterBuilders.TryGetValue(
                                mapping.DevName,
                                out var characterBuilder))
                            {
                                characterBuilder = new CharacterBuilder
                                {
                                    DeveloperName = mapping.DevName,
                                    EnglishLocilizationName = mapping.EnglishLocalizedName,
                                    Id = mapping.StackableId,
                                    IdRangeName = mapping.IdRangeName,
                                    LocalizedName = mapping.LocalizedName,
                                    ProgressBuilder = new ProgressBuilder(),
                                    CharacterStatsBuilder = new CharacterStatsBuilder(),
                                    Modes = new ModesBuilder(new Dictionary<string, ModeBuilder>())
                                };


                                playerStatsBuilder.CharactersBuilder.CharacterBuilders.Add(
                                    mapping.DevName,
                                    characterBuilder);
                            }


                            switch (mapping.StackableRangeName)
                            {
                                case "Characters":
                                    characterBuilder.Appereance = new Appereance(mapping.Icon, mapping.WideIcon);
                                    continue;
                                case "XP":
                                    characterBuilder.ProgressBuilder.Experience = value;
                                    continue;

                                case "CharacterWins":
                                    characterBuilder.CharacterStatsBuilder.Won = value;
                                    continue;

                                case "CharacterLosses":
                                    characterBuilder.CharacterStatsBuilder.Lost = value;
                                    continue;

                                case "CharacterKills":
                                    characterBuilder.CharacterStatsBuilder.Kills = value;
                                    continue;

                                case "CharacterDeaths":
                                    characterBuilder.CharacterStatsBuilder.Deaths = value;
                                    continue;

                                case "Level":
                                    characterBuilder.ProgressBuilder.Level = value;
                                    continue;

                                case "CharacterTimePlayed":
                                    characterBuilder.CharacterStatsBuilder.TimePlayed = value;
                                    continue;

                                case "CharacterRanked2v2Wins":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterRanked2v2").Won = value;
                                    continue;

                                case "CharacterRanked2v2Losses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterRanked2v2").Lost = value;
                                    continue;

                                case "CharacterRanked3v3Wins":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterRanked3v3").Won = value;
                                    continue;

                                case "CharacterRanked3v3Losses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterRanked3v3").Lost = value;
                                    continue;

                                case "CharacterUnranked2v2Wins":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterUnranked2v2").Won = value;
                                    continue;

                                case "CharacterUnranked2v2Losses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterUnranked2v2").Lost = value;
                                    continue;

                                case "CharacterUnranked3v3Wins":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterUnranked3v3").Won = value;
                                    continue;

                                case "CharacterUnranked3v3Losses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterUnranked3v3").Lost = value;
                                    continue;

                                case "CharacterBrawlWins":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterBrawl").Won = value;
                                    continue;
                                case "CharacterBrawlLosses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterBrawl").Lost = value;
                                    continue;
                                case "CharacterBrawl3v3Losses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterBrawl").Lost = value;
                                    continue;

                                case "CharacterBattlegroundsWins":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterBattlegrounds").Won = value;
                                    continue;
                                case "CharacterBattlegroundsLosses":
                                    GetOrAddMode(characterBuilder.Modes, "CharacterBattlegrounds").Lost = value;
                                    continue;
                                case "VsAIPlayed":
                                    GetOrAddMode(characterBuilder.Modes, "AI").Won = value;
                                    continue;
                                default:
                                    throw new ArgumentOutOfRangeException(
                                        nameof(mapping.StackableRangeName),
                                        mapping.StackableRangeName);
                            }
                        case IdRangeName.Empty:

                            switch (mapping.StackableRangeName)
                            {
                                case "Wins":
                                    playerStatsBuilder.Won = value;
                                    continue;
                                case "Losses":
                                    playerStatsBuilder.Lost = value;
                                    continue;
                                case "GradeScore":
                                    playerStatsBuilder.RatingBuilder.GradeScore = value;
                                    continue;
                                //case "VsAIPlayed":
                                //    GetOrAddMode(playerStatsBuilder.ModesBuilder, "VsAIPlayed").;
                                //    continue;
                                case "TimePlayed":
                                    playerStatsBuilder.TimePlayed = value;
                                    continue;
                                case "RatingMean":
                                    playerStatsBuilder.RatingBuilder.Mean = value;
                                    continue;
                                case "RatingDev":
                                    playerStatsBuilder.RatingBuilder.Dev = value;
                                    continue;
                                case "Unranked3v3Wins":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Unranked3v3").Won = value;
                                    continue;
                                case "Unranked3v3Losses":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Unranked3v3").Lost = value;
                                    continue;
                                case "Ranked3v3Wins":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Ranked3v3").Won = value;
                                    continue;
                                case "Ranked3v3Losses":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Ranked3v3").Lost = value;
                                    continue;
                                case "Ranked2v2Wins":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Ranked2v2").Won = value;

                                    continue;
                                case "Ranked2v2Losses":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Ranked2v2").Lost = value;

                                    continue;
                                case "Unranked2v2Losses":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Unranked2v2").Lost = value;

                                    continue;
                                case "Unranked2v2Wins":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Unranked2v2").Won = value;

                                    continue;
                                case "BrawlWins":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Brawl").Won = value;

                                    continue;
                                case "BrawlLosses":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Brawl").Lost = value;

                                    continue;
                                case "AccountXP":
                                    playerStatsBuilder.ProgressBuilder.Experience = value;

                                    continue;
                                case "AccountLevel":
                                    playerStatsBuilder.ProgressBuilder.Level = value;
                                    continue;
                                case "BattlegroundsWins":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Battlegrounds").Won = value;
                                    continue;
                                case "BattlegroundsLosses":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "Battlegrounds").Lost = value;
                                    continue;

                                case "VsAIPlayed":
                                    GetOrAddMode(playerStatsBuilder.ModesBuilder, "AI").Won = value;
                                    continue;

                                case "TwitchAccountLinked":
                                    playerStatsBuilder.ThirdPartyAccountsBuilder.ThirdPartyAccountBuilders.Add(
                                        "TwitchAccountLinked",
                                        new ThirdPartyAccountBuilder
                                        {
                                            Name = "Twitch"
                                        });
                                    continue;

                                default:
                                    throw new ArgumentOutOfRangeException(mapping.StackableRangeName);
                            }

                        case IdRangeName.Map:
                            throw new NotImplementedException(mapping.IdRangeName.ToString());

                        case IdRangeName.Mount:
                            throw new NotImplementedException(mapping.IdRangeName.ToString());

                        case IdRangeName.Outfit:
                            throw new NotImplementedException(mapping.IdRangeName.ToString());

                        case IdRangeName.VictoryPose:
                            throw new NotImplementedException(mapping.IdRangeName.ToString());

                        default:
                            throw new ArgumentOutOfRangeException(mapping.IdRangeName.ToString());
                    }
                }

            return new PopulatedAttributes(
                jObject["name"].ToObject<string>(),
                jObject["patchVersion"].ToObject<string>(),
                jObject["shardId"].ToObject<string>(),
                playerStatsBuilder.Build());
        }

        public override void WriteJson(JsonWriter writer, PopulatedAttributes value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private static ModeBuilder GetOrAddMode(ModesBuilder modesBuilder, string value)
        {
            if (modesBuilder.ModeBuilders.TryGetValue(value, out var result))
                return result;

            var modeBuilder = new ModeBuilder
            {
                Name = value
            };

            modesBuilder.ModeBuilders.Add(value, modeBuilder);
            return modeBuilder;
        }
    }
}