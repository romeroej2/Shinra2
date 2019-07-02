using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class RedMageOpener
    {
        private static RedMageSpells Spells { get; } = new RedMageSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.Acceleration,
            Spells.Veraero,
            Spells.Verthunder,
            Spells.Verstone,
            Spells.Veraero,
            Spells.Fleche,
            Spells.ContreSixte,
            Spells.JoltII,
            Spells.Verthunder,
            Spells.Role.Swiftcast,
            Spells.Verthunder,
            Spells.CorpsACorps,
            Spells.Embolden,
            Spells.Impact,
            Spells.Veraero,
            Spells.Manafication,
            Spells.CorpsACorps,
            Spells.EnchantedRiposte,
            Spells.EnchantedZwerchhau,
            Spells.EnchantedRedoublement,
            Spells.Verflare,
            Spells.Scorch
        };
    }
}