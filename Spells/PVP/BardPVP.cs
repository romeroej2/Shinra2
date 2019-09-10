namespace ShinraCo.Spells.PVP
{
    public class BardPVP
    {
        public Spell BurstShot { get; } = new Spell
        {
            Name = "Burst Shot",
            ID = 17745,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell CausticBite { get; } = new Spell
        {
            Name = "Caustic Bite",
            ID = 8836,
            GCDType = GCDType.On,
            Combo = 17,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Stormbite { get; } = new Spell
        {
            Name = "Stormbite",
            ID = 8837,
            GCDType = GCDType.On,
            Combo = 17,
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

        public Spell ApexArrow { get; } = new Spell
        {
            Name = "Apex Arrow",
            ID = 17747,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
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

        public Spell PitchPerfect { get; } = new Spell
        {
            Name = "Pitch Perfect",
            ID = 8842,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
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