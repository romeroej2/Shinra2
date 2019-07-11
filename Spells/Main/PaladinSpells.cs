using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class GladiatorSpells
    {
        public PaladinPVP PVP { get; } = new PaladinPVP();
        public TankSpells Role { get; } = new TankSpells();

        public Spell FastBlade { get; } = new Spell
        {
            Name = "Fast Blade",
            ID = 9,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FightOrFlight { get; } = new Spell
        {
            Name = "Fight or Flight",
            ID = 20,
            Level = 2,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell RiotBlade { get; } = new Spell
        {
            Name = "Riot Blade",
            ID = 15,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell TotalEclipse { get; } = new Spell
        {
            Name = "Total Eclipse",
            ID = 7381,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };
        
        public Spell ShieldBash { get; } = new Spell
        {
            Name = "Shield Bash",
            ID = 16,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell IronWill { get; } = new Spell
        {
            Name = "Iron Will",
            ID = 28,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        
        public Spell ShieldLob { get; } = new Spell
        {
            Name = "Shield Lob",
            ID = 24,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell RageOfHalone { get; } = new Spell
        {
            Name = "Rage of Halone",
            ID = 21,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }

    public class PaladinSpells : GladiatorSpells
    {
        public Spell SpiritsWithin { get; } = new Spell
        {
            Name = "Spirits Within",
            ID = 29,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
        
        public Spell Sheltron { get; } = new Spell
        {
            Name = "Sheltron",
            ID = 3542,
            Level = 35,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        
        public Spell Sentinel { get; } = new Spell
        {
            Name = "Sentinel",
            ID = 17,
            Level = 38,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        
        public Spell Prominence { get; } = new Spell
        {
            Name = "Prominence",
            ID = 16457,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };
        
        public Spell Cover { get; } = new Spell
        {
            Name = "Cover",
            ID = 27,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };
        
        public Spell CircleOfScorn { get; } = new Spell
        {
            Name = "Circle of Scorn",
            ID = 23,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };
        
        public Spell HallowedGround { get; } = new Spell
        {
            Name = "Hallowed Ground",
            ID = 30,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        
        public Spell GoringBlade { get; } = new Spell
        {
            Name = "Goring Blade",
            ID = 3538,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DivineVeil { get; } = new Spell
        {
            Name = "Divine Veil",
            ID = 3540,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Clemency { get; } = new Spell
        {
            Name = "Clemency",
            ID = 3541,
            Level = 58,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell RoyalAuthority { get; } = new Spell
        {
            Name = "Royal Authority",
            ID = 3539,
            Level = 60,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Intervention { get; } = new Spell
        {
            Name = "Intervention",
            ID = 7382,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell HolySpirit { get; } = new Spell
        {
            Name = "Holy Spirit",
            ID = 7384,
            Level = 64,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Requiescat { get; } = new Spell
        {
            Name = "Requiescat",
            ID = 7383,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell PassageOfArms { get; } = new Spell
        {
            Name = "Passage of Arms",
            ID = 7385,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        
        
        public Spell HolyCircle { get; } = new Spell
        {
            Name = "Holy Circle",
            ID = 16458,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };
        
        public Spell Intervene { get; } = new Spell
        {
            Name = "Intervene",
            ID = 16461,
            Level = 74,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };
        
        public Spell Atonement { get; } = new Spell
        {
            Name = "Atonement",
            ID = 16460,
            Level = 76,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
        
        public Spell Confiteor { get; } = new Spell
        {
            Name = "Confiteor",
            ID = 16459,
            Level = 80,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
        
    }
}