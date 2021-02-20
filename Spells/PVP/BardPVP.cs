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

        public Spell Shadowbite { get; } = new Spell
        {
            Name = "Shadowbite",
            ID = 18931,
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

    }
}