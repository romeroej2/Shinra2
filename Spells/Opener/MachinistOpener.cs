using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class MachinistOpener
    {
        private static MachinistSpells Spells { get; } = new MachinistSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.HotShot,
            Spells.GaussRound,
            Spells.SplitShot,
            Spells.Reload,
            Spells.SlugShot,
            Spells.Flamethrower,
            Spells.SplitShot,
            Spells.Reassemble,
            Spells.Wildfire,
            Spells.CleanShot,
            Spells.QuickReload,
            Spells.RapidFire,
            Spells.SlugShot,
            Spells.GaussRound,
            Spells.CleanShot,
            Spells.Ricochet,
            Spells.Cooldown,
            Spells.RookOverdrive,
            Spells.Cooldown
        };
    }
}