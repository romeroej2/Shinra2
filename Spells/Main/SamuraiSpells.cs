using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class SamuraiSpells
    {
        public SamuraiPVP PVP { get; } = new SamuraiPVP();
        public MeleeSpells Role { get; } = new MeleeSpells();

        public Spell Hakaze { get; } = new Spell
        {
            Name = "Hakaze",
            ID = 7477,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Jinpu { get; } = new Spell
        {
            Name = "Jinpu",
            ID = 7478,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell ThirdEye { get; } = new Spell
        {
            Name = "Third Eye",
            ID = 7498,
            Level = 6,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Ageha { get; } = new Spell
        {
            Name = "Ageha",
            ID = 7500,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Enpi { get; } = new Spell
        {
            Name = "Enpi",
            ID = 7486,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Shifu { get; } = new Spell
        {
            Name = "Shifu",
            ID = 7479,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Fuga { get; } = new Spell
        {
            Name = "Fuga",
            ID = 7483,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell Gekko { get; } = new Spell
        {
            Name = "Gekko",
            ID = 7481,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Higanbana { get; } = new Spell
        {
            Name = "Higanbana",
            ID = 7867,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell TenkaGoken { get; } = new Spell
        {
            Name = "Tenka Goken",
            ID = 7867,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell MidareSetsugekka { get; } = new Spell
        {
            Name = "Midare Setsugekka",
            ID = 7867,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Mangetsu { get; } = new Spell
        {
            Name = "Mangetsu",
            ID = 7484,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell Kasha { get; } = new Spell
        {
            Name = "Kasha",
            ID = 7482,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Oka { get; } = new Spell
        {
            Name = "Oka",
            ID = 7485,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell Yukikaze { get; } = new Spell
        {
            Name = "Yukikaze",
            ID = 7480,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell MeikyoShisui { get; } = new Spell
        {
            Name = "Meikyo Shisui",
            ID = 7499,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell HissatsuKaiten { get; } = new Spell
        {
            Name = "Hissatsu: Kaiten",
            ID = 7494,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell HissatsuGyoten { get; } = new Spell
        {
            Name = "Hissatsu: Gyoten",
            ID = 7492,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell HissatsuYaten { get; } = new Spell
        {
            Name = "Hissatsu: Yaten",
            ID = 7493,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell MercifulEyes { get; } = new Spell
        {
            Name = "Merciful Eyes",
            ID = 7502,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell Meditate { get; } = new Spell
        {
            Name = "Meditate",
            ID = 7497,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell HissatsuShinten { get; } = new Spell
        {
            Name = "Hissatsu: Shinten",
            ID = 7490,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell HissatsuKyuten { get; } = new Spell
        {
            Name = "Hissatsu: Kyuten",
            ID = 7491,
            Level = 64,
            GCDType = GCDType.Off,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell HissatsuSeigan { get; } = new Spell
        {
            Name = "Hissatsu: Seigan",
            ID = 7501,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Hagakure { get; } = new Spell
        {
            Name = "Hagakure",
            ID = 7495,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell HissatsuGuren { get; } = new Spell
        {
            Name = "Hissatsu: Guren",
            ID = 7496,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}