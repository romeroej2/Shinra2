namespace ShinraCo.Spells.PVP
{
    public class SamuraiPVP
    {
        public Spell Hakaze { get; } = new Spell
        {
            Name = "Hakaze",
            ID = 8821,
            Combo = 13,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Yukikaze { get; } = new Spell
        {
            Name = "Yukikaze",
            ID = 8824,
            Combo = 13,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Jinpu { get; } = new Spell
        {
            Name = "Jinpu",
            ID = 8822,
            Combo = 14,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Gekko { get; } = new Spell
        {
            Name = "Gekko",
            ID = 8825,
            Combo = 14,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Shifu { get; } = new Spell
        {
            Name = "Shifu",
            ID = 8823,
            Combo = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Kasha { get; } = new Spell
        {
            Name = "Kasha",
            ID = 8826,
            Combo = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Enpi { get; } = new Spell
        {
            Name = "Enpi",
            ID = 8827,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell HissatsuShinten { get; } = new Spell
        {
            Name = "Hissatsu: Shinten",
            ID = 8832,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell MeikyoShisui { get; } = new Spell
        {
            Name = "Meikyo Shisui",
            ID = 8833,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Higanbana { get; } = new Spell
        {
            Name = "Higanbana",
            ID = 8829,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell TenkaGoken { get; } = new Spell
        {
            Name = "Tenka Goken",
            ID = 8830,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell MidareSetsugekka { get; } = new Spell
        {
            Name = "Midare Setsugekka",
            ID = 8831,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }
}