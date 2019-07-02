using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class ScholarSpells : ArcanistSpells
    {
        public new HealerSpells Role { get; } = new HealerSpells();
//start
        public Spell Ruin { get; } = new Spell
        {
            Name = "Ruin",
            ID = 17869,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Bio { get; } = new Spell
        {
            Name = "Bio",
            ID = 17864,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };
		//EOS
        public Spell Summon { get; } = new Spell
        {
            Name = "Summon",
            ID = 17215,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Physick { get; } = new Spell
        {
            Name = "Physick",
            ID = 190,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Aetherflow { get; } = new Spell
        {
            Name = "Aetherflow",
            ID = 166,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

		//selene
        public Spell SummonII { get; } = new Spell
        {
            Name = "Summon II",
            ID = 17216,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Sustain { get; } = new Spell
        {
            Name = "Sustain",
            ID = 171,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell Resurrection { get; } = new Spell
        {
            Name = "Resurrection",
            ID = 173,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell BioII { get; } = new Spell
        {
            Name = "Bio II",
            ID = 17865,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Biolysis { get; } = new Spell
        {
            Name = "Biolysis",
            ID = 16540,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };
		
        public Spell ArtOfWar { get; } = new Spell
        {
            Name = "Bane",
            ID = 16539,
            Level = 46,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell RuinII { get; } = new Spell
        {
            Name = "Ruin II",
            ID = 17870,
            Level = 38,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
		

 //stop
        public Spell Adloquium { get; } = new Spell
        {
            Name = "Adloquium",
            ID = 185,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Succor { get; } = new Spell
        {
            Name = "Succor",
            ID = 186,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell SacredSoil { get; } = new Spell
        {
            Name = "Sacred Soil",
            ID = 188,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.TargetLocation
        };

        public Spell Lustrate { get; } = new Spell
        {
            Name = "Lustrate",
            ID = 189,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Indomitability { get; } = new Spell
        {
            Name = "Indomitability",
            ID = 3583,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell Broil { get; } = new Spell
        {
            Name = "Broil",
            ID = 3584,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DeploymentTactics { get; } = new Spell
        {
            Name = "Deployment Tactics",
            ID = 3585,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell EmergencyTactics { get; } = new Spell
        {
            Name = "Emergency Tactics",
            ID = 3586,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Dissipation { get; } = new Spell
        {
            Name = "Dissipation",
            ID = 3587,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Excogitation { get; } = new Spell
        {
            Name = "Excogitation",
            ID = 7434,
            Level = 62,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell BroilII { get; } = new Spell
        {
            Name = "Broil II",
            ID = 7435,
            Level = 64,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BroilIII { get; } = new Spell
        {
            Name = "Broil III",
            ID = 16541,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
		
        public Spell ChainStrategem { get; } = new Spell
        {
            Name = "Chain Strategem",
            ID = 7436,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Aetherpact { get; } = new Spell
        {
            Name = "Aetherpact",
            ID = 7437,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell DissolveUnion { get; } = new Spell
        {
            Name = "Dissolve Union",
            ID = 7869,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}