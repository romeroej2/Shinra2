using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class BlackMageOpener
    {
        private static BlackMageSpells Spells { get; } = new BlackMageSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.BlizzardIII,
            Spells.Enochian,
            Spells.ThunderIII,
            Spells.BlizzardIV,
            Spells.FireIII,
            Spells.Triplecast,
            Spells.FireIV,
            Spells.LeyLines,
            Spells.FireIV,
            Spells.Sharpcast,
            Spells.FireIV,
            Spells.Fire,
            Spells.FireIV,
            Spells.FireIV,
            Spells.FireIII,
            Spells.Convert
        };
    }
}