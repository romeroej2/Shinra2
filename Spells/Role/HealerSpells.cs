namespace ShinraCo.Spells.Role
{
    public class HealerSpells
    {
        public Spell ClericStance { get; } = new Spell
        {
            Name = "Cleric Stance",
            ID = 7567,
            Level = 8,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
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

        public Spell Protect { get; } = new Spell
        {
            Name = "Protect",
            ID = 7572,
            Level = 16,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Esuna { get; } = new Spell
        {
            Name = "Esuna",
            ID = 7568,
            Level = 20,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell LucidDreaming { get; } = new Spell
        {
            Name = "Lucid Dreaming",
            ID = 7562,
            Level = 24,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Swiftcast { get; } = new Spell
        {
            Name = "Swiftcast",
            ID = 7561,
            Level = 32,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell EyeForAnEye { get; } = new Spell
        {
            Name = "Eye for an Eye",
            ID = 7569,
            Level = 36,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Largesse { get; } = new Spell
        {
            Name = "Largesse",
            ID = 7570,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Surecast { get; } = new Spell
        {
            Name = "Surecast",
            ID = 7559,
            Level = 44,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Rescue { get; } = new Spell
        {
            Name = "Rescue",
            ID = 7571,
            Level = 48,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };
    }
}