using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class DragoonOpener
    {
        private static DragoonSpells Spells { get; } = new DragoonSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.HeavyThrust,
            Spells.BloodOfTheDragon,
            Spells.DragonSight,
            Spells.ImpulseDrive,
            Spells.BattleLitany,
            Spells.BloodForBlood,
            Spells.Disembowel,
            Spells.ChaosThrust,
            Spells.Jump,
            Spells.WheelingThrust,
            Spells.Geirskogul,
            Spells.MirageDive,
            Spells.FangAndClaw,
            Spells.SpineshatterDive,
            Spells.TrueThrust,
            Spells.DragonfireDive,
            Spells.VorpalThrust,
            Spells.LifeSurge,
            Spells.MirageDive,
            Spells.FullThrust
        };
    }
}
