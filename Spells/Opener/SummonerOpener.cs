using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class SummonerOpener
    {
        private static SummonerSpells Spells { get; } = new SummonerSpells();

        public static List<Spell> List = new List<Spell>
        {

            Spells.EgiAssault,//1
            Spells.EnergyDrain,
            Spells.TriDisaster,
            Spells.EgiAssaultII,//2 potion
            Spells.EgiAssault,//3
            Spells.Aetherpact,
            Spells.DreadwyrmTrance,
            Spells.EgiAssaultII,//4
            Spells.Role.LucidDreaming,
            Spells.Enkindle,
            Spells.RuinIII,//5
            Spells.Fester,
            Spells.TriDisaster,
            Spells.RuinIII,//6
            Spells.Deathflare,
            Spells.SummonBahamut,
            Spells.RuinIV,//7
            Spells.EnkindleBahamut,
            Spells.Fester,
            Spells.RuinIV,//8
            Spells.RuinIII,//9
            Spells.RuinIII,//10
            Spells.RuinIV,//11
            Spells.EnkindleBahamut,
            Spells.RuinIII,//12
            Spells.RuinIV,//13
            Spells.EnergyDrain,
            Spells.Role.Swiftcast,
            Spells.RuinIII,//14
            Spells.Fester
        };
    }
}