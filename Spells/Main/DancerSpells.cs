using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class DancerSpells
    {
        public RangedSpells Role { get; } = new RangedSpells();

        // Single Target
        public Spell Cascade { get; } = new Spell
        {
            Name = "Cascade",
            ID = 15989,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Fountain { get; } = new Spell
        {
            Name = "Fountain",
            ID = 15990,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ReverseCascade { get; } = new Spell
        {
            Name = "Reverse Cascade",
            ID = 15991,
            Level = 20,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Fountainfall { get; } = new Spell
        {
            Name = "Fountainfall",
            ID = 15992,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FanDanceI { get; } = new Spell
        {
            Name = "Fan Dance I",
            ID = 16007,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FanDanceIII { get; } = new Spell
        {
            Name = "Fan Dance III",
            ID = 16009,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell SaberDance { get; } = new Spell
        {
            Name = "Saber Dance",
            ID = 16005,
            Level = 76,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        // Aoe
        public Spell Windmill { get; } = new Spell
        {
            Name = "Windmill",
            ID = 15993,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Self
        };

        public Spell RisingWindmill { get; } = new Spell
        {
            Name = "Rising Windmill",
            ID = 15995,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Self
        };

        public Spell Bladeshower { get; } = new Spell
        {
            Name = "Bladeshower",
            ID = 15994,
            Level = 25,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Self
        };

        public Spell Bloodshower { get; } = new Spell
        {
            Name = "Bloodshower",
            ID = 15996,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Self
        };

        public Spell FanDanceII { get; } = new Spell
        {
            Name = "Fan Dance II",
            ID = 16008,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Self
        };

        // Dance Partner

        public Spell ClosedPosition { get; } = new Spell
        {
            Name = "Closed Position",
            ID = 16006,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Devilment { get; } = new Spell
        {
            Name = "Devilment",
            ID = 16011,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell CuringWaltz { get; } = new Spell
        {
            Name = "Curing Waltz",
            ID = 16015,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        // Utility
        public Spell Flourish { get; } = new Spell
        {
            Name = "Flourish",
            ID = 16013,
            Level = 72,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        // Dancing
        public Spell StandardStep { get; } = new Spell
        {
            Name = "Standard Step",
            ID = 15997,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell TechnicalStep { get; } = new Spell
        {
            Name = "Technical Step",
            ID = 15998,
            Level = 70,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Emboite { get; } = new Spell
        {
            Name = "Emboite",
            ID = 15999,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        public Spell Jete { get; } = new Spell
        {
            Name = "Jete",
            ID = 16001,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        public Spell Entrechat { get; } = new Spell
        {
            Name = "Entrechat",
            ID = 16000,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        public Spell Pirouette { get; } = new Spell
        {
            Name = "Pirouette",
            ID = 16002,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        public Spell StandardFinish { get; } = new Spell
        {
            Name = "Standard Finish",
            ID = 16192,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell TechnicalFinish { get; } = new Spell
        {
            Name = "Technical Finish",
            ID = 16196,
            Level = 70,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        // ShieldSamba
        // Improvisation
        // En Avant
    }
}
