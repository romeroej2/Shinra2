using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class PaladinOpener
    {
        private static PaladinSpells Spells { get; } = new PaladinSpells();

        public static readonly List<Spell> List = new List<Spell>
        {
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.FightOrFlight,
            Spells.GoringBlade,
            Spells.RageOfHalone,
            Spells.RoyalAuthority,
            Spells.Atonement,
            Spells.Atonement,
            Spells.Atonement,
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.GoringBlade,
            Spells.Requiescat,
            Spells.HolySpirit,
            Spells.HolySpirit,
            Spells.HolySpirit,
            Spells.HolySpirit,
            Spells.Confiteor,
            Spells.FastBlade,
            Spells.RiotBlade,
            Spells.RageOfHalone,
            Spells.RoyalAuthority,
            Spells.Atonement,
            Spells.Atonement,
            Spells.Atonement
        };
    }
}