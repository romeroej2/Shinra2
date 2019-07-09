namespace ShinraCo.Spells.Role
{
    public class MeleeSpells
    {
        public Spell SecondWind { get; } = new Spell
        {
            Name = "Second Wind",
            ID = 7541,
            Level = 8,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell LegSweep { get; } = new Spell
        {
            Name = "Leg Sweep",
            ID = 7863,
            Level = 16,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Diversion { get; } = new Spell
        {
            Name = "Diversion",
            ID = 7545,
            Level = 20,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Invigorate { get; } = new Spell
        {
            Name = "Invigorate",
            ID = 7544,
            Level = 24,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Bloodbath { get; } = new Spell
        {
            Name = "Bloodbath",
            ID = 7542,
            Level = 32,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Goad { get; } = new Spell
        {
            Name = "Goad",
            ID = 7543,
            Level = 36,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Feint { get; } = new Spell
        {
            Name = "Feint",
            ID = 7549,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Crutch { get; } = new Spell
        {
            Name = "Crutch",
            ID = 7547,
            Level = 44,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell TrueNorth { get; } = new Spell
        {
            Name = "True North",
            ID = 7546,
            Level = 48,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}