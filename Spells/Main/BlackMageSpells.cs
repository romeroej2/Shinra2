using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class ThaumaturgeSpells
    {
        public BlackMagePVP PVP { get; } = new BlackMagePVP();
        public CasterSpells Role { get; } = new CasterSpells();

        public Spell Blizzard { get; } = new Spell
        {
            Name = "Blizzard",
            ID = 142,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Fire { get; } = new Spell
        {
            Name = "Fire",
            ID = 141,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Transpose { get; } = new Spell
        {
            Name = "Transpose",
            ID = 149,
            Level = 4,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Thunder { get; } = new Spell
        {
            Name = "Thunder",
            ID = 144,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Sleep { get; } = new Spell
        {
            Name = "Sleep",
            ID = 145,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BlizzardII { get; } = new Spell
        {
            Name = "Blizzard II",
            ID = 146,
            Level = 12,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Self
        };

        public Spell Scathe { get; } = new Spell
        {
            Name = "Scathe",
            ID = 156,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FireII { get; } = new Spell
        {
            Name = "Fire II",
            ID = 147,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ThunderII { get; } = new Spell
        {
            Name = "Thunder II",
            ID = 7447,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Manaward { get; } = new Spell
        {
            Name = "Manaward",
            ID = 157,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell FireIII { get; } = new Spell
        {
            Name = "Fire III",
            ID = 152,
            Level = 34,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell AetherialManipulation { get; } = new Spell
        {
            Name = "Aetherial Manipulation",
            ID = 155,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }

    public class BlackMageSpells : ThaumaturgeSpells
    {
        public Spell Convert { get; } = new Spell
        {
            Name = "Convert",
            ID = 158,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Freeze { get; } = new Spell
        {
            Name = "Freeze",
            ID = 159,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.TargetLocation
        };

        public Spell BlizzardIII { get; } = new Spell
        {
            Name = "Blizzard III",
            ID = 154,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ThunderIII { get; } = new Spell
        {
            Name = "Thunder III",
            ID = 153,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Thundercloud { get; } = new Spell
        {
            Name = "Thundercloud",
            ID = 153,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Flare { get; } = new Spell
        {
            Name = "Flare",
            ID = 162,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell LeyLines { get; } = new Spell
        {
            Name = "Ley Lines",
            ID = 3573,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Sharpcast { get; } = new Spell
        {
            Name = "Sharpcast",
            ID = 3574,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Enochian { get; } = new Spell
        {
            Name = "Enochian",
            ID = 3575,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell BlizzardIV { get; } = new Spell
        {
            Name = "Blizzard IV",
            ID = 3576,
            Level = 58,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FireIV { get; } = new Spell
        {
            Name = "Fire IV",
            ID = 3577,
            Level = 60,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BetweenTheLines { get; } = new Spell
        {
            Name = "Between The Lines",
            ID = 7419,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell ThunderIV { get; } = new Spell
        {
            Name = "Thunder IV",
            ID = 7420,
            Level = 64,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Triplecast { get; } = new Spell
        {
            Name = "Triplecast",
            ID = 7421,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Foul { get; } = new Spell
        {
            Name = "Foul",
            ID = 7422,
            Level = 70,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };


        public Spell Despair { get; } = new Spell
        {
            Name = "Despair",
            ID = 16505,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell UmbralSoul { get; } = new Spell
        {
            Name = "Umbral Soul",
            ID = 16506,
            Level = 76,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };


        public Spell Xenoglossy { get; } = new Spell
        {
            Name = "Xenoglossy",
            ID = 16507,
            Level = 80,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

    }
}