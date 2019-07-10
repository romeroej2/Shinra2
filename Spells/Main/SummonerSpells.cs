using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class ArcanistSpells
    {
        public SummonerPVP PVP { get; } = new SummonerPVP();
        public CasterSpells Role { get; } = new CasterSpells();

        public Spell Ruin { get; } = new Spell
        {
            Name = "Ruin",
            ID = 163,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Bio { get; } = new Spell
        {
            Name = "Bio",
            ID = 164,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Summon { get; } = new Spell
        {
            Name = "Summon",
            ID = 165,
            Level = 4,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Physick { get; } = new Spell
        {
            Name = "Physick",
            ID = 16230,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };
        public Spell Miasma { get; } = new Spell
        {
            Name = "Miasma",
            ID = 168,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell EgiAssault { get; } = new Spell
        {
            Name = "Egi Assault",
            ID = 16509,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Resurrection { get; } = new Spell
        {
            Name = "Resurrection",
            ID = 173,
            Level = 12,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell SummonII { get; } = new Spell
        {
            Name = "Summon II",
            ID = 170,
            Level = 15,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Fester { get; } = new Spell
        {
            Name = "Fester",
            ID = 181,
            Level = 18,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell EnergyDrain { get; } = new Spell
        {
            Name = "Energy Drain",
            ID = 16508,
            Level = 18,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell BioII { get; } = new Spell
        {
            Name = "Bio II",
            ID = 178,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Bane { get; } = new Spell
        {
            Name = "Bane",
            ID = 174,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell RuinII { get; } = new Spell
        {
            Name = "Ruin II",
            ID = 172,
            Level = 38,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell EgiAssaultII { get; } = new Spell
        {
            Name = "Egi Assault II",
            ID = 16512,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

    }

    public class SummonerSpells : ArcanistSpells
    {
        public Spell SummonIII { get; } = new Spell
        {
            Name = "Summon III",
            ID = 180,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell EnergySiphon { get; } = new Spell
        {
            Name = "Energy Siphon",
            ID = 16510,
            Level = 35,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Outburst { get; } = new Spell
        {
            Name = "Outburst",
            ID = 16511,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell Enkindle { get; } = new Spell
        {
            Name = "Enkindle",
            ID = 184,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Painflare { get; } = new Spell
        {
            Name = "Painflare",
            ID = 3578,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RuinIII { get; } = new Spell
        {
            Name = "Ruin III",
            ID = 3579,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell TriDisaster { get; } = new Spell
        {
            Name = "Tri-disaster",
            ID = 3580,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell DreadwyrmTrance { get; } = new Spell
        {
            Name = "Dreadwyrm Trance",
            ID = 3581,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Deathflare { get; } = new Spell
        {
            Name = "Deathflare",
            ID = 3582,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell RuinIV { get; } = new Spell
        {
            Name = "Ruin IV",
            ID = 7426,
            Level = 62,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Aetherpact { get; } = new Spell
        {
            Name = "Aetherpact",
            ID = 7423,
            Level = 64,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell BioIII { get; } = new Spell
        {
            Name = "Bio III",
            ID = 7424,
            Level = 66,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell MiasmaIII { get; } = new Spell
        {
            Name = "Miasma III",
            ID = 7425,
            Level = 66,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell SummonBahamut { get; } = new Spell
        {
            Name = "Summon Bahamut",
            ID = 7427,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell EnkindleBahamut { get; } = new Spell
        {
            Name = "Enkindle Bahamut",
            ID = 7429,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell FountainOfFire { get; } = new Spell
        {
            Name = "Fountain Of Fire",
            ID = 16514,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BrandOfPurgatory { get; } = new Spell
        {
            Name = "Brand Of Purgatory",
            ID = 16515,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FirebirdTrance { get; } = new Spell
        {
            Name = "Firebird Trance",
            ID = 16513,
            Level = 72,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell EnkindlePhoenix{ get; } = new Spell
        {
            Name = "Enkindle Phoenix",
            ID = 16516,
            Level = 80,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}