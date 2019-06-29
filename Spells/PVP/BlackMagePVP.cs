namespace ShinraCo.Spells.PVP
{
    public class BlackMagePVP
    {
        public Spell Fire { get; } = new Spell
        {
            Name = "Fire",
            ID = 8858,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Blizzard { get; } = new Spell
        {
            Name = "Blizzard",
            ID = 8859,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Thunder { get; } = new Spell
        {
            Name = "Thunder",
            ID = 8860,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell ThunderIII { get; } = new Spell
        {
            Name = "Thunder III",
            ID = 8861,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Enochian { get; } = new Spell
        {
            Name = "Enochian",
            ID = 8862,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell FireIV { get; } = new Spell
        {
            Name = "Fire IV",
            ID = 8863,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BlizzardIV { get; } = new Spell
        {
            Name = "Blizzard IV",
            ID = 8864,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Foul { get; } = new Spell
        {
            Name = "Foul",
            ID = 8865,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Flare { get; } = new Spell
        {
            Name = "Flare",
            ID = 8866,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Freeze { get; } = new Spell
        {
            Name = "Freeze",
            ID = 8867,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Swiftcast { get; } = new Spell
        {
            Name = "Swiftcast",
            ID = 8870,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Convert { get; } = new Spell
        {
            Name = "Convert",
            ID = 9637,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}