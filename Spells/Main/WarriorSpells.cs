using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class MarauderSpells
    {
        public TankSpells Role { get; } = new TankSpells();

        public Spell HeavySwing { get; } = new Spell
        {
            Name = "Heavy Swing",
            ID = 31,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell SkullSunder { get; } = new Spell
        {
            Name = "Skull Sunder",
            ID = 35,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Berserk { get; } = new Spell
        {
            Name = "Berserk",
            ID = 38,
            Level = 6,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Overpower { get; } = new Spell
        {
            Name = "Overpower",
            ID = 41,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell Tomahawk { get; } = new Spell
        {
            Name = "Tomahawk",
            ID = 46,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Maim { get; } = new Spell
        {
            Name = "Maim",
            ID = 37,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ThrillOfBattle { get; } = new Spell
        {
            Name = "Thrill of Battle",
            ID = 40,
            Level = 26,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell ButchersBlock { get; } = new Spell
        {
            Name = "Butcher's Block",
            ID = 47,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell StormsPath { get; } = new Spell
        {
            Name = "Storm's Path",
            ID = 42,
            Level = 38,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Holmgang { get; } = new Spell
        {
            Name = "Holmgang",
            ID = 43,
            Level = 42,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Vengeance { get; } = new Spell
        {
            Name = "Vengeance",
            ID = 44,
            Level = 46,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell StormsEye { get; } = new Spell
        {
            Name = "Storm's Eye",
            ID = 45,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }

    public class WarriorSpells : MarauderSpells
    {
        public Spell Defiance { get; } = new Spell
        {
            Name = "Defiance",
            ID = 48,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell InnerBeast { get; } = new Spell
        {
            Name = "Inner Beast",
            ID = 49,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Unchained { get; } = new Spell
        {
            Name = "Unchained",
            ID = 50,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell SteelCyclone { get; } = new Spell
        {
            Name = "Steel Cyclone",
            ID = 51,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell Infuriate { get; } = new Spell
        {
            Name = "Infuriate",
            ID = 52,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Deliverance { get; } = new Spell
        {
            Name = "Deliverance",
            ID = 3548,
            Level = 52,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell FellCleave { get; } = new Spell
        {
            Name = "Fell Cleave",
            ID = 3549,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell RawIntuition { get; } = new Spell
        {
            Name = "Raw Intuition",
            ID = 3551,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Equilibrium { get; } = new Spell
        {
            Name = "Equilibrium",
            ID = 3552,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell Decimate { get; } = new Spell
        {
            Name = "Decimate",
            ID = 3550,
            Level = 60,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell Onslaught { get; } = new Spell
        {
            Name = "Onslaught",
            ID = 7386,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Upheaval { get; } = new Spell
        {
            Name = "Upheaval",
            ID = 7387,
            Level = 64,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ShakeItOff { get; } = new Spell
        {
            Name = "Shake it Off",
            ID = 7388,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell InnerRelease { get; } = new Spell
        {
            Name = "Inner Release",
            ID = 7389,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}