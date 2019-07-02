using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class LancerSpells
    {
        public DragoonPVP PVP { get; } = new DragoonPVP();
        public MeleeSpells Role { get; } = new MeleeSpells();

        public Spell TrueThrust { get; } = new Spell
        {
            Name = "True Thrust",
            ID = 75,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell VorpalThrust { get; } = new Spell
        {
            Name = "Vorpal Thrust",
            ID = 78,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ImpulseDrive { get; } = new Spell
        {
            Name = "Impulse Drive",
            ID = 81,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell HeavyThrust { get; } = new Spell
        {
            Name = "Heavy Thrust",
            ID = 79,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell PiercingTalon { get; } = new Spell
        {
            Name = "Piercing Talon",
            ID = 90,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell LifeSurge { get; } = new Spell
        {
            Name = "Life Surge",
            ID = 83,
            Level = 18,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell FullThrust { get; } = new Spell
        {
            Name = "Full Thrust",
            ID = 84,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BloodForBlood { get; } = new Spell
        {
            Name = "Blood for Blood",
            ID = 85,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Disembowel { get; } = new Spell
        {
            Name = "Disembowel",
            ID = 87,
            Level = 38,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ChaosThrust { get; } = new Spell
        {
            Name = "Chaos Thrust",
            ID = 88,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }

    public class DragoonSpells : LancerSpells
    {
        public Spell Jump { get; } = new Spell
        {
            Name = "Jump",
            ID = 92,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ElusiveJump { get; } = new Spell
        {
            Name = "Elusive Jump",
            ID = 94,
            Level = 35,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell DoomSpike { get; } = new Spell
        {
            Name = "Doom Spike",
            ID = 86,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell SpineshatterDive { get; } = new Spell
        {
            Name = "Spineshatter Dive",
            ID = 95,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell DragonfireDive { get; } = new Spell
        {
            Name = "Dragonfire Dive",
            ID = 96,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell BattleLitany { get; } = new Spell
        {
            Name = "Battle Litany",
            ID = 3557,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell BloodOfTheDragon { get; } = new Spell
        {
            Name = "Blood of the Dragon",
            ID = 3553,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell FangAndClaw { get; } = new Spell
        {
            Name = "Fang and Claw",
            ID = 3554,
            Level = 56,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell WheelingThrust { get; } = new Spell
        {
            Name = "Wheeling Thrust",
            ID = 3556,
            Level = 58,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Geirskogul { get; } = new Spell
        {
            Name = "Geirskogul",
            ID = 3555,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell SonicThrust { get; } = new Spell
        {
            Name = "Sonic Thrust",
            ID = 7397,
            Level = 62,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell DragonSight { get; } = new Spell
        {
            Name = "Dragon Sight",
            ID = 7398,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell MirageDive { get; } = new Spell
        {
            Name = "Mirage Dive",
            ID = 7399,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Nastrond { get; } = new Spell
        {
            Name = "Nastrond",
            ID = 7400,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
        
        public Spell CoerthanTorment { get; } = new Spell
        {
            Name = "Coerthan Torment",
            ID = 16477,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.SelfLocation
        };
        
        public Spell HighJump { get; } = new Spell
        {
            Name = "High Jump",
            ID = 16478,
            Level = 74,
            GCDType = GCDType.Off,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };
        
        public Spell RaidenThrust { get; } = new Spell
        {
            Name = "Raiden Thrust",
            ID = 16479,
            Level = 76,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
        
        public Spell Stardiver { get; } = new Spell
        {
            Name = "Stardiver",
            ID = 16480,
            Level = 80,
            GCDType = GCDType.Off,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };
    }
}