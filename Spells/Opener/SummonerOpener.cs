using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class SummonerOpener
    {
        private static SummonerSpells Spells { get; } = new SummonerSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.TriDisaster,
            Spells.RuinII,
            Spells.EgiAssault,
            Spells.DreadwyrmTrance,
            Spells.RuinIII, //1 
            Spells.EnergyDrain,
            Spells.EgiAssaultII,
            Spells.RuinIII, //2
            Spells.EgiAssault,
            Spells.Aetherpact,
            Spells.RuinIII, //3
            Spells.RuinIII, //4
            Spells.Enkindle,
            Spells.EgiAssaultII,
            Spells.RuinIII, //5
            Spells.Fester,
            Spells.TriDisaster,
            Spells.RuinIII, //6
            Spells.Deathflare,
            Spells.SummonBahamut,
            Spells.RuinIV,
            Spells.EnkindleBahamut,
            Spells.Fester,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIV,
            Spells.EnkindleBahamut,
            Spells.Role.Swiftcast,
            Spells.RuinIII,
            Spells.EnergyDrain,
            Spells.Fester,
            Spells.RuinIV,
            Spells.EgiAssault,
            Spells.RuinIII,
            Spells.MiasmaIII,
            Spells.BioIII,
            Spells.EgiAssaultII,
            Spells.Fester,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIII,
            Spells.RuinIV,
            Spells.EnergyDrain,
            Spells.EgiAssault,
            Spells.RuinIV,
            Spells.EgiAssaultII,
            Spells.RuinIII,
            Spells.RuinIV,
            Spells.TriDisaster,
            Spells.FirebirdTrance
        };
    }
}