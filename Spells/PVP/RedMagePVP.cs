namespace ShinraCo.Spells.PVP
{
    public class RedMagePVP
    {
        public Spell JoltII { get; } = new Spell
        {
            Name = "Jolt II",
            ID = 9444,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Impact { get; } = new Spell
        {
            Name = "Impact",
            ID = 8886,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verstone { get; } = new Spell
        {
            Name = "Verstone",
            ID = 8883,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Veraero { get; } = new Spell
        {
            Name = "Veraero",
            ID = 8882,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verfire { get; } = new Spell
        {
            Name = "Verfire",
            ID = 8885,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verthunder { get; } = new Spell
        {
            Name = "Verthunder",
            ID = 8884,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell CorpsACorps { get; } = new Spell
        {
            Name = "Corps-a-corps",
            ID = 8890,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell EnchantedRiposte { get; } = new Spell
        {
            Name = "Enchanted Riposte",
            ID = 8887,
            Combo = 19,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell EnchantedZwerchhau { get; } = new Spell
        {
            Name = "Enchanted Zwerchhau",
            ID = 8888,
            Combo = 19,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell EnchantedRedoublement { get; } = new Spell
        {
            Name = "Enchanted Redoublement",
            ID = 8889,
            Combo = 19,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Verholy { get; } = new Spell
        {
            Name = "Verholy",
            ID = 9433,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verflare { get; } = new Spell
        {
            Name = "Verflare",
            ID = 9434,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }
}