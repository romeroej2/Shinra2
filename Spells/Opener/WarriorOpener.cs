using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class WarriorOpener
    {
        private static WarriorSpells Spells { get; } = new WarriorSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.HeavySwing,
            Spells.Infuriate,
            Spells.Maim,
            Spells.ThrillOfBattle,
            Spells.StormsEye,
            Spells.FellCleave,
            Spells.InnerRelease,
            Spells.FellCleave,
            Spells.Upheaval,
            Spells.Onslaught,
            Spells.FellCleave,
            Spells.FellCleave,
            Spells.FellCleave,
            Spells.FellCleave
        };
    }
}
