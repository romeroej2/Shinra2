namespace ShinraCo.Spells.Role
{
    public class CasterSpells
    {
        public Spell Addle { get; } = new Spell
        {
            Name = "Addle",
            ID = 7560,
            Level = 8,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Break { get; } = new Spell
        {
            Name = "Break",
            ID = 7558,
            Level = 12,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Drain { get; } = new Spell
        {
            Name = "Drain",
            ID = 7564,
            Level = 16,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
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

        public Spell LucidDreaming { get; } = new Spell
        {
            Name = "Lucid Dreaming",
            ID = 7562,
            Level = 24,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Swiftcast { get; } = new Spell
        {
            Name = "Swiftcast",
            ID = 7561,
            Level = 32,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell ManaShift { get; } = new Spell
        {
            Name = "Mana Shift",
            ID = 7565,
            Level = 36,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Apocatastasis { get; } = new Spell
        {
            Name = "Apocatastasis",
            ID = 7563,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Surecast { get; } = new Spell
        {
            Name = "Surecast",
            ID = 7559,
            Level = 44,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Erase { get; } = new Spell
        {
            Name = "Erase",
            ID = 7566,
            Level = 48,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };
    }
}