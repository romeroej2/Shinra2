using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class NinjaOpener
    {
        private static NinjaSpells Spells { get; } = new NinjaSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.SpinningEdge,
            Spells.Ten,
            Spells.Chi,
            Spells.Jin,
            Spells.Ninjutsu,
            Spells.GustSlash,
            Spells.Kassatsu,
            Spells.ShadowFang,
            Spells.Mug,
            Spells.SpinningEdge,
            Spells.Jugulate,
            Spells.GustSlash,
            Spells.TrickAttack,
            Spells.AeolianEdge,
            Spells.Ten,
            Spells.Chi,
            Spells.Ninjutsu,
            Spells.SpinningEdge,
            Spells.DreamWithinADream,
            Spells.GustSlash,
            Spells.Duality,
            Spells.AeolianEdge,
            Spells.Bhavacakra
        };
    }
}
