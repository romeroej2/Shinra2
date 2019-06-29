using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class PugilistSpells
    {
        public MonkPVP PVP { get; } = new MonkPVP();
        public MeleeSpells Role { get; } = new MeleeSpells();

        public Spell Bootshine { get; } = new Spell
        {
            Name = "Bootshine",
            ID = 53,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell TrueStrike { get; } = new Spell
        {
            Name = "True Strike",
            ID = 54,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell SnapPunch { get; } = new Spell
        {
            Name = "Snap Punch",
            ID = 56,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell InternalRelease { get; } = new Spell
        {
            Name = "Internal Release",
            ID = 59,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell FistsOfEarth { get; } = new Spell
        {
            Name = "Fists of Earth",
            ID = 60,
            Level = 15,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell TwinSnakes { get; } = new Spell
        {
            Name = "Twin Snakes",
            ID = 61,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ArmOfTheDestroyer { get; } = new Spell
        {
            Name = "Arm of the Destroyer",
            ID = 62,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell Demolish { get; } = new Spell
        {
            Name = "Demolish",
            ID = 66,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell FistsOfWind { get; } = new Spell
        {
            Name = "Fists of Wind",
            ID = 73,
            Level = 34,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell SteelPeak { get; } = new Spell
        {
            Name = "Steel Peak",
            ID = 64,
            Level = 38,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Mantra { get; } = new Spell
        {
            Name = "Mantra",
            ID = 65,
            Level = 42,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell HowlingFist { get; } = new Spell
        {
            Name = "Howling Fist",
            ID = 67,
            Level = 46,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell PerfectBalance { get; } = new Spell
        {
            Name = "Perfect Balance",
            ID = 69,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }

    public class MonkSpells : PugilistSpells
    {
        public Spell Rockbreaker { get; } = new Spell
        {
            Name = "Rockbreaker",
            ID = 70,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell ShoulderTackle { get; } = new Spell
        {
            Name = "Shoulder Tackle",
            ID = 71,
            Level = 35,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell FistsOfFire { get; } = new Spell
        {
            Name = "Fists of Fire",
            ID = 63,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell OneIlmPunch { get; } = new Spell
        {
            Name = "One Ilm Punch",
            ID = 72,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DragonKick { get; } = new Spell
        {
            Name = "Dragon Kick",
            ID = 74,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FormShift { get; } = new Spell
        {
            Name = "Form Shift",
            ID = 4262,
            Level = 52,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell Meditation { get; } = new Spell
        {
            Name = "Meditation",
            ID = 3546,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell ForbiddenChakra { get; } = new Spell
        {
            Name = "The Forbidden Chakra",
            ID = 3547,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ElixirField { get; } = new Spell
        {
            Name = "Elixir Field",
            ID = 3545,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Purification { get; } = new Spell
        {
            Name = "Purification",
            ID = 3544,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell TornadoKick { get; } = new Spell
        {
            Name = "Tornado Kick",
            ID = 3543,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RiddleOfEarth { get; } = new Spell
        {
            Name = "Riddle of Earth",
            ID = 7394,
            Level = 64,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell EarthTackle { get; } = new Spell
        {
            Name = "Earth Tackle",
            ID = 7864,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell WindTackle { get; } = new Spell
        {
            Name = "Wind Tackle",
            ID = 7865,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell FireTackle { get; } = new Spell
        {
            Name = "Fire Tackle",
            ID = 7866,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RiddleOfWind { get; } = new Spell
        {
            Name = "Riddle of Wind",
            ID = 7868,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RiddleOfFire { get; } = new Spell
        {
            Name = "Riddle of Fire",
            ID = 7395,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Brotherhood { get; } = new Spell
        {
            Name = "Brotherhood",
            ID = 7396,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}