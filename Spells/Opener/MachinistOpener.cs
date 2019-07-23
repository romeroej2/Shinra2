using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class MachinistOpener
    {
        private static MachinistSpells Spells { get; } = new MachinistSpells();

        public static List<Spell> List = new List<Spell>
        {
			Spells.Drill,
			Spells.GaussRound,
			Spells.Ricochet,
			Spells.SplitShot,
			Spells.BarrelStabilizer,
			Spells.GaussRound,
			Spells.SlugShot,
			Spells.Wildfire,
			Spells.Hypercharge,
			Spells.Heatblast,
			Spells.Ricochet,
			Spells.Heatblast,
			Spells.GaussRound,
			Spells.Heatblast,
			Spells.Ricochet,
			Spells.Heatblast,
			Spells.GaussRound,
			Spells.Heatblast,
			Spells.Reassemble,
			Spells.HotShot,
			Spells.GaussRound,
			Spells.Ricochet,
			Spells.CleanShot,
			Spells.GaussRound,
			Spells.Ricochet,
			Spells.Drill,
			Spells.Ricochet
        };
    }
}