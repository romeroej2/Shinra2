using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class RogueSpells
    {
        public MeleeSpells Role { get; } = new MeleeSpells();

        public Spell SpinningEdge { get; } = new Spell
        {
            Name = "Spinning Edge",
            ID = 2240,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ShadeShift { get; } = new Spell
        {
            Name = "Shade Shift",
            ID = 2241,
            Level = 2,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell GustSlash { get; } = new Spell
        {
            Name = "Gust Slash",
            ID = 2242,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Hide { get; } = new Spell
        {
            Name = "Hide",
            ID = 2245,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Assassinate { get; } = new Spell
        {
            Name = "Assassinate",
            ID = 2246,
            Level = 12,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ThrowingDagger { get; } = new Spell
        {
            Name = "Throwing Dagger",
            ID = 2247,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Mug { get; } = new Spell
        {
            Name = "Mug",
            ID = 2248,
            Level = 15,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell TrickAttack { get; } = new Spell
        {
            Name = "Trick Attack",
            ID = 2258,
            Level = 18,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell AeolianEdge { get; } = new Spell
        {
            Name = "Aeolian Edge",
            ID = 2255,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Jugulate { get; } = new Spell
        {
            Name = "Jugulate",
            ID = 2256,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ShadowFang { get; } = new Spell
        {
            Name = "Shadow Fang",
            ID = 2257,
            Level = 38,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DeathBlossom { get; } = new Spell
        {
            Name = "Death Blossom",
            ID = 2254,
            Level = 42,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };
    }

    public class NinjaSpells : RogueSpells
    {
        public Spell Ten { get; } = new Spell
        {
            Name = "Ten",
            ID = 2259,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Mudra,
            CastType = CastType.Self
        };

        public Spell Ninjutsu { get; } = new Spell
        {
            Name = "Ninjutsu",
            ID = 2260,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Target
        };

        public Spell FumaShuriken { get; } = new Spell
        {
            Name = "Fuma Shuriken",
            ID = 2265,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Target
        };

        public Spell Chi { get; } = new Spell
        {
            Name = "Chi",
            ID = 2261,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Mudra,
            CastType = CastType.Self
        };

        public Spell Katon { get; } = new Spell
        {
            Name = "Katon",
            ID = 2266,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Target
        };

        public Spell Raiton { get; } = new Spell
        {
            Name = "Raiton",
            ID = 2267,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Target
        };

        public Spell Shukuchi { get; } = new Spell
        {
            Name = "Shukuchi",
            ID = 2262,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.TargetLocation
        };

        public Spell Jin { get; } = new Spell
        {
            Name = "Jin",
            ID = 2263,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Mudra,
            CastType = CastType.Self
        };

        public Spell Hyoton { get; } = new Spell
        {
            Name = "Hyoton",
            ID = 2268,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Target
        };

        public Spell Huton { get; } = new Spell
        {
            Name = "Huton",
            ID = 2269,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Self
        };

        public Spell Doton { get; } = new Spell
        {
            Name = "Doton",
            ID = 2270,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.SelfLocation
        };

        public Spell Suiton { get; } = new Spell
        {
            Name = "Suiton",
            ID = 2271,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Ninjutsu,
            CastType = CastType.Target
        };

        public Spell Kassatsu { get; } = new Spell
        {
            Name = "Kassatsu",
            ID = 2264,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell SmokeScreen { get; } = new Spell
        {
            Name = "Smoke Screen",
            ID = 3565,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell ArmorCrush { get; } = new Spell
        {
            Name = "Armor Crush",
            ID = 3563,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Shadewalker { get; } = new Spell
        {
            Name = "Shadewalker",
            ID = 3564,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell Duality { get; } = new Spell
        {
            Name = "Duality",
            ID = 3567,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell DreamWithinADream { get; } = new Spell
        {
            Name = "Dream Within a Dream",
            ID = 3566,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell HellfrogMedium { get; } = new Spell
        {
            Name = "Hellfrog Medium",
            ID = 7401,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Bhavacakra { get; } = new Spell
        {
            Name = "Bhavacakra",
            ID = 7402,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell TenChiJin { get; } = new Spell
        {
            Name = "Ten Chi Jin",
            ID = 7403,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}