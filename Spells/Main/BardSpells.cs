using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class ArcherSpells
    {
        public BardPVP PVP { get; } = new BardPVP();
        public RangedSpells Role { get; } = new RangedSpells();

        public Spell HeavyShot { get; } = new Spell
        {
            Name = "Heavy Shot",
            ID = 97,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell StraightShot { get; } = new Spell
        {
            Name = "Straight Shot",
            ID = 98,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell RagingStrikes { get; } = new Spell
        {
            Name = "Raging Strikes",
            ID = 101,
            Level = 4,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell VenomousBite { get; } = new Spell
        {
            Name = "Venomous Bite",
            ID = 100,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell MiserysEnd { get; } = new Spell
        {
            Name = "Misery's End",
            ID = 103,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Bloodletter { get; } = new Spell
        {
            Name = "Bloodletter",
            ID = 110,
            Level = 12,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell RepellingShot { get; } = new Spell
        {
            Name = "Repelling Shot",
            ID = 112,
            Level = 15,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell QuickNock { get; } = new Spell
        {
            Name = "Quick Nock",
            ID = 106,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Windbite { get; } = new Spell
        {
            Name = "Windbite",
            ID = 113,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Barrage { get; } = new Spell
        {
            Name = "Barrage",
            ID = 107,
            Level = 38,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }

    public class BardSpells : ArcherSpells
    {
        public Spell MagesBallad { get; } = new Spell
        {
            Name = "Mage's Ballad",
            ID = 114,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell FoeRequiem { get; } = new Spell
        {
            Name = "Foe Requiem",
            ID = 115,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell ArmysPaeon { get; } = new Spell
        {
            Name = "Army's Paeon",
            ID = 116,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RainOfDeath { get; } = new Spell
        {
            Name = "Rain of Death",
            ID = 117,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BattleVoice { get; } = new Spell
        {
            Name = "Battle Voice",
            ID = 118,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell WanderersMinuet { get; } = new Spell
        {
            Name = "The Wanderer's Minuet",
            ID = 3559,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell PitchPerfect { get; } = new Spell
        {
            Name = "Pitch Perfect",
            ID = 7404,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell EmpyrealArrow { get; } = new Spell
        {
            Name = "Empyreal Arrow",
            ID = 3558,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell IronJaws { get; } = new Spell
        {
            Name = "Iron Jaws",
            ID = 3560,
            Level = 56,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell TheWardensPaean { get; } = new Spell
        {
            Name = "The Warden's Paean",
            ID = 3561,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Sidewinder { get; } = new Spell
        {
            Name = "Sidewinder",
            ID = 3562,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        // Troubadour
        // Caustic Bite
        // Stormbite
        // Nature's Minne

        public Spell RefulgentArrow { get; } = new Spell
        {
            Name = "Refulgent Arrow",
            ID = 7409,
            Level = 70,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }
}