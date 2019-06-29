using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class BardOpener
    {
        private static BardSpells Spells { get; } = new BardSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.Windbite,
            Spells.Bloodletter,
            Spells.RagingStrikes,
            Spells.VenomousBite,
            Spells.WanderersMinuet,
            Spells.BattleVoice,
            Spells.StraightShot,
            Spells.EmpyrealArrow,
            Spells.IronJaws,
            Spells.Sidewinder
        };
    }
}