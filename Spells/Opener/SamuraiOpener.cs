using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class SamuraiOpener
    {
        private static SamuraiSpells Spells { get; } = new SamuraiSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.Hakaze,
            Spells.Shifu,
            Spells.Kasha,
            Spells.Hakaze,
            Spells.Jinpu,
            Spells.HissatsuShinten,
            Spells.Gekko,
            Spells.MeikyoShisui,
            Spells.Yukikaze,
            Spells.Hagakure,
            Spells.Gekko,
            Spells.HissatsuGuren,
            Spells.HissatsuKaiten,
            Spells.Higanbana,
            Spells.Yukikaze
        };
    }
}
