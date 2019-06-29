using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class PaladinOpener
    {
        private static PaladinSpells Spells { get; } = new PaladinSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.FightOrFlight,
            Spells.GoringBlade,
            Spells.CircleOfScorn,
            Spells.SpiritsWithin,
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.RoyalAuthority,
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.RoyalAuthority,
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.GoringBlade,
            Spells.Requiescat,
            Spells.HolySpirit,
            Spells.CircleOfScorn,
            Spells.HolySpirit,
            Spells.HolySpirit,
            Spells.HolySpirit,
            Spells.SpiritsWithin,
            Spells.HolySpirit
        };
    }
}