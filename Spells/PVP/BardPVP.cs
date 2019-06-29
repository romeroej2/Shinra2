namespace ShinraCo.Spells.PVP
{
    public class BardPVP
    {
        public Spell StraightShot { get; } = new Spell
        {
            Name = "Straight Shot",
            ID = 8835,
            Combo = 16,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Stormbite { get; } = new Spell
        {
            Name = "Stormbite",
            ID = 8837,
            Combo = 17,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell EmpyrealArrow { get; } = new Spell
        {
            Name = "Empyreal Arrow",
            ID = 8838,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Sidewinder { get; } = new Spell
        {
            Name = "Sidewinder",
            ID = 8841,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Bloodletter { get; } = new Spell
        {
            Name = "Bloodletter",
            ID = 9624,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Barrage { get; } = new Spell
        {
            Name = "Barrage",
            ID = 9625,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell WanderersMinuet { get; } = new Spell
        {
            Name = "Wanderer's Minuet",
            ID = 8843,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell ArmysPaeon { get; } = new Spell
        {
            Name = "Army's Paeon",
            ID = 8844,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Troubadour { get; } = new Spell
        {
            Name = "Troubadour",
            ID = 10023,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}