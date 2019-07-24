using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class MachinistSpells
    {
        public RangedSpells Role { get; } = new RangedSpells();

        public Spell SplitShot { get; } = new Spell
        {
            Name = "Split Shot",
            ID = 2866,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell SlugShot { get; } = new Spell
        {
            Name = "Slug Shot",
            ID = 2868,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Reassemble { get; } = new Spell
        {
            Name = "Reassemble",
            ID = 2876,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell SpreadShot { get; } = new Spell
        {
            Name = "Spread Shot",
            ID = 2870,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
		
		public Spell Crossbow { get; } = new Spell
        {
            Name = "Auto Crossbow",
            ID = 16497,
            Level = 25,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell HotShot { get; } = new Spell
        {
            Name = "Hot Shot",
            ID = 2872,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell CleanShot { get; } = new Spell
        {
            Name = "Clean Shot",
            ID = 2873,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Wildfire { get; } = new Spell
        {
            Name = "Wildfire",
            ID = 2878,
            Level = 38,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RookAutoturret { get; } = new Spell
        {
            Name = "Rook Autoturret",
            ID = 2864,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell GaussRound { get; } = new Spell
        {
            Name = "Gauss Round",
            ID = 2874,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Hypercharge { get; } = new Spell
        {
            Name = "Hypercharge",
            ID = 17209,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Ricochet { get; } = new Spell
        {
            Name = "Ricochet",
            ID = 2890,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell BarrelStabilizer { get; } = new Spell
        {
            Name = "Barrel Stabilizer",
            ID = 7414,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell RookOverdrive { get; } = new Spell
        {
            Name = "Rook Overdrive",
            ID = 7415,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Flamethrower { get; } = new Spell
        {
            Name = "Flamethrower",
            ID = 7418,
            Level = 70,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };
		
		public Spell Bioblaster { get; } = new Spell
        {
            Name = "Bioblaster",
            ID = 16499,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
		
		public Spell Drill { get; } = new Spell
        {
            Name = "Drill",
            ID = 16498,
            Level = 58,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
		
		public Spell Heatblast { get; } = new Spell
        {
            Name = "Heat Blast",
            ID = 7410,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}