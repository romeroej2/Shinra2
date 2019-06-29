namespace ShinraCo.Spells.PVP
{
    public class DragoonPVP
    {
        public Spell TrueThrust { get; } = new Spell
        {
            Name = "True Thrust",
            ID = 8791,
            Combo = 9,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell FullThrust { get; } = new Spell
        {
            Name = "Full Thrust",
            ID = 8793,
            Combo = 9,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell FangAndClaw { get; } = new Spell
        {
            Name = "Fang and Claw",
            ID = 8794,
            Combo = 9,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell ChaosThrust { get; } = new Spell
        {
            Name = "Chaos Thrust",
            ID = 8797,
            Combo = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell WheelingThrust { get; } = new Spell
        {
            Name = "Wheeling Thrust",
            ID = 8798,
            Combo = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Skewer { get; } = new Spell
        {
            Name = "Skewer",
            ID = 1567,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Jump { get; } = new Spell
        {
            Name = "Jump",
            ID = 8801,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell SpineshatterDive { get; } = new Spell
        {
            Name = "Spineshatter Dive",
            ID = 8802,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell BloodOfTheDragon { get; } = new Spell
        {
            Name = "Blood of the Dragon",
            ID = 8804,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Geirskogul { get; } = new Spell
        {
            Name = "Geirskogul",
            ID = 8805,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Nastrond { get; } = new Spell
        {
            Name = "Nastrond",
            ID = 8806,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}