using ShinraCo.Spells.PVP;
using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class RedMageSpells
    {
        public RedMagePVP PVP { get; } = new RedMagePVP();
        public CasterSpells Role { get; } = new CasterSpells();

        public Spell Riposte { get; } = new Spell
        {
            Name = "Riposte",
            ID = 7504,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell EnchantedRiposte { get; } = new Spell
        {
            Name = "Enchanted Riposte",
            ID = 7527,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Jolt { get; } = new Spell
        {
            Name = "Jolt",
            ID = 7503,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verthunder { get; } = new Spell
        {
            Name = "Verthunder",
            ID = 7505,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell CorpsACorps { get; } = new Spell
        {
            Name = "Corps-a-corps",
            ID = 7506,
            Level = 6,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Veraero { get; } = new Spell
        {
            Name = "Veraero",
            ID = 7507,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Scatter { get; } = new Spell
        {
            Name = "Scatter",
            ID = 7509,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell VerthunderII { get; } = new Spell
        {
            Name = "Verthunder II",
            ID = 16524,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell VeraeroII { get; } = new Spell
        {
            Name = "Veraero II",
            ID = 16525,
            Level = 22,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell Verfire { get; } = new Spell
        {
            Name = "Verfire",
            ID = 7510,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verstone { get; } = new Spell
        {
            Name = "Verstone",
            ID = 7511,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Zwerchhau { get; } = new Spell
        {
            Name = "Zwerchhau",
            ID = 7512,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell EnchantedZwerchhau { get; } = new Spell
        {
            Name = "Enchanted Zwerchhau",
            ID = 7528,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Displacement { get; } = new Spell
        {
            Name = "Displacement",
            ID = 7515,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Fleche { get; } = new Spell
        {
            Name = "Fleche",
            ID = 7517,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Redoublement { get; } = new Spell
        {
            Name = "Redoublement",
            ID = 7516,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell EnchantedRedoublement { get; } = new Spell
        {
            Name = "Enchanted Redoublement",
            ID = 7529,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Acceleration { get; } = new Spell
        {
            Name = "Acceleration",
            ID = 7518,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Moulinet { get; } = new Spell
        {
            Name = "Moulinet",
            ID = 7513,
            Level = 52,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell EnchantedMoulinet { get; } = new Spell
        {
            Name = "Enchanted Moulinet",
            ID = 7530,
            Level = 52,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell Vercure { get; } = new Spell
        {
            Name = "Vercure",
            ID = 7514,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell ContreSixte { get; } = new Spell
        {
            Name = "Contre Sixte",
            ID = 7519,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Embolden { get; } = new Spell
        {
            Name = "Embolden",
            ID = 7520,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Manafication { get; } = new Spell
        {
            Name = "Manafication",
            ID = 7521,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell JoltII { get; } = new Spell
        {
            Name = "Jolt II",
            ID = 7524,
            Level = 62,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verraise { get; } = new Spell
        {
            Name = "Verraise",
            ID = 7523,
            Level = 64,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Impact { get; } = new Spell
        {
            Name = "Impact",
            ID = 16526,
            Level = 66,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

        public Spell Verflare { get; } = new Spell
        {
            Name = "Verflare",
            ID = 7525,
            Level = 68,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Verholy { get; } = new Spell
        {
            Name = "Verholy",
            ID = 7526,
            Level = 70,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        //Shadowbringers
        public Spell Engagement { get; } = new Spell
        {
            Name = "Engagement",
            ID = 16527,
            Level = 72,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Reprise { get; } = new Spell
        {
            Name = "Reprise",
            ID = 16529,
            Level = 76,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell EnchantedReprise { get; } = new Spell
        {
            Name = "Enchanted Reprise",
            ID = 16528,
            Level = 76,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Scorch { get; } = new Spell
        {
            Name = "Scorch",
            ID = 16530,
            Level = 80,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };



    }
}