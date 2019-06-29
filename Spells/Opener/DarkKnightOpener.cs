using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class DarkKnightOpener
    {
        private static DarkKnightSpells Spells { get; } = new DarkKnightSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.HardSlash,
            Spells.DarkArts,
            Spells.SyphonStrike,
            Spells.Souleater,
            Spells.SaltedEarth,
            Spells.BloodWeapon,
            Spells.HardSlash,
            Spells.DarkArts,
            Spells.SoleSurvivor,
            Spells.SyphonStrike,
            Spells.DarkArts,
            Spells.Delirium,
            Spells.Souleater,
            Spells.Plunge,
            Spells.DarkArts,
            Spells.HardSlash,
            Spells.CarveAndSpit,
            Spells.DarkArts,
            Spells.SyphonStrike,
            Spells.DarkPassenger,
            Spells.DarkArts,
            Spells.Bloodspiller
        };
    }
}
