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
            Spells.DreadwyrmTrance,
            Spells.RuinIII,
            Spells.EnergyDrain,
            Spells.EgiAssault,
            Spells.RuinIII,
            Spells.EgiAssaultII,
            Spells.Aetherpact,
            Spells.RuinIII,
            Spells.EgiAssault,
            Spells.RuinIII,
            Spells.Enkindle,
            Spells.TriDisaster,
            Spells.RuinIII,
            Spells.Fester,
            Spells.EgiAssaultII,
            Spells.RuinIII,
            Spells.Deathflare,
            Spells.SummonBahamut,
            Spells.RuinIV,
            Spells.Fester,
            Spells.EnkindleBahamut,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIV,
            Spells.Role.Swiftcast,
            Spells.EnkindleBahamut,
        };
    }
}