using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class SummonerOpener
    {
        private static SummonerSpells Spells { get; } = new SummonerSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.RuinIII,
            Spells.RuinII,
            Spells.TriDisaster,
            Spells.RuinII,
            Spells.Fester,
            Spells.Role.Swiftcast,
            Spells.SummonIII,
            Spells.Painflare,
            Spells.Aetherpact,
            Spells.RuinII,
            Spells.Fester,
            Spells.DreadwyrmTrance,
            Spells.RuinIII,
            Spells.TriDisaster,
            Spells.Rouse,
            Spells.RuinIII,
            Spells.ShadowFlare,
            Spells.Deathflare,
            Spells.RuinII,
            Spells.Aetherflow,
            Spells.Enkindle,
            Spells.RuinII,
            Spells.Fester,
            Spells.RuinIII,
            Spells.RuinII,
            Spells.Fester,
            Spells.RuinIII,
            Spells.RuinII,
            Spells.Fester,
            Spells.RuinII,
            Spells.DreadwyrmTrance,
            Spells.TriDisaster
        };
    }
}