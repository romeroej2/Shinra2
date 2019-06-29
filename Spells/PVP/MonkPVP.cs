namespace ShinraCo.Spells.PVP
{
    public class MonkPVP
    {
        public Spell Bootshine { get; } = new Spell
        {
            Name = "Bootshine",
            ID = 8780,
            Combo = 7,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell SnapPunch { get; } = new Spell
        {
            Name = "Snap Punch",
            ID = 8782,
            Combo = 7,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Demolish { get; } = new Spell
        {
            Name = "Demolish",
            ID = 8785,
            Combo = 8,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Somersault { get; } = new Spell
        {
            Name = "Somersault",
            ID = 1564,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell TheForbiddenChakra { get; } = new Spell
        {
            Name = "The Forbidden Chakra",
            ID = 8790,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell FormShift { get; } = new Spell
        {
            Name = "Form Shift",
            ID = 8786,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell TornadoKick { get; } = new Spell
        {
            Name = "Tornado Kick",
            ID = 8789,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RiddleOfFire { get; } = new Spell
        {
            Name = "Riddle of Fire",
            ID = 9639,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}