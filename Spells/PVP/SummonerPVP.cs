namespace ShinraCo.Spells.PVP
{
    public class SummonerPVP
    {
        public Spell RuinIII { get; } = new Spell
        {
            Name = "Ruin III",
            ID = 8872,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BioIII { get; } = new Spell
        {
            Name = "Bio III",
            ID = 8873,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell MiasmaIII { get; } = new Spell
        {
            Name = "Miasma III",
            ID = 8874,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Wither { get; } = new Spell
        {
            Name = "Wither",
            ID = 1576,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Aetherflow { get; } = new Spell
        {
            Name = "Aetherflow",
            ID = 8876,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell EnergyDrain { get; } = new Spell
        {
            Name = "Energy Drain",
            ID = 9618,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Fester { get; } = new Spell
        {
            Name = "Fester",
            ID = 8877,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell DreadwyrmTrance { get; } = new Spell
        {
            Name = "Dreadwyrm Trance",
            ID = 9013,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell SummonBahamut { get; } = new Spell
        {
            Name = "Summon Bahamut",
            ID = 8878,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Deathflare { get; } = new Spell
        {
            Name = "Deathflare",
            ID = 9014,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell EnkindleBahamut { get; } = new Spell
        {
            Name = "Enkindle Bahamut",
            ID = 8880,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}