namespace ShinraCo.Spells.Role
{
    public class RangedSpells
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

        public Spell FootGraze { get; } = new Spell
        {
            Name = "Foot Graze",
            ID = 7553,
            Level = 12,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell LegGraze { get; } = new Spell
        {
            Name = "Leg Graze",
            ID = 7554,
            Level = 16,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Peloton { get; } = new Spell
        {
            Name = "Peloton",
            ID = 7557,
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

        public Spell Tactician { get; } = new Spell
        {
            Name = "Tactician",
            ID = 7555,
            Level = 32,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Refresh { get; } = new Spell
        {
            Name = "Refresh",
            ID = 7556,
            Level = 36,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell HeadGraze { get; } = new Spell
        {
            Name = "Head Graze",
            ID = 7551,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ArmGraze { get; } = new Spell
        {
            Name = "Arm Graze",
            ID = 7552,
            Level = 44,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Palisade { get; } = new Spell
        {
            Name = "Palisade",
            ID = 7550,
            Level = 48,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };
    }
}