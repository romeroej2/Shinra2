using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class ConjurerSpells
    {
        public HealerSpells Role { get; } = new HealerSpells();

        public Spell Stone { get; } = new Spell
        {
            Name = "Stone",
            ID = 119,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Cure { get; } = new Spell
        {
            Name = "Cure",
            ID = 120,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Aero { get; } = new Spell
        {
            Name = "Aero",
            ID = 121,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell Medica { get; } = new Spell
        {
            Name = "Medica",
            ID = 124,
            Level = 10,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };

        public Spell Raise { get; } = new Spell
        {
            Name = "Raise",
            ID = 125,
            Level = 12,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell FluidAura { get; } = new Spell
        {
            Name = "Fluid Aura",
            ID = 134,
            Level = 15,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell StoneII { get; } = new Spell
        {
            Name = "Stone II",
            ID = 127,
            Level = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell CureII { get; } = new Spell
        {
            Name = "Cure II",
            ID = 135,
            Level = 30,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell AeroII { get; } = new Spell
        {
            Name = "Aero II",
            ID = 132,
            Level = 46,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };

        public Spell MedicaII { get; } = new Spell
        {
            Name = "Medica II",
            ID = 133,
            Level = 50,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };
    }

    public class WhiteMageSpells : ConjurerSpells
    {
        public Spell PresenceOfMind { get; } = new Spell
        {
            Name = "Presence of Mind",
            ID = 136,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Regen { get; } = new Spell
        {
            Name = "Regen",
            ID = 137,
            Level = 35,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell CureIII { get; } = new Spell
        {
            Name = "Cure III",
            ID = 131,
            Level = 40,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Holy { get; } = new Spell
        {
            Name = "Holy",
            ID = 139,
            Level = 45,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell AfflatusSolace { get; } = new Spell
        {
            Name = "Afflatus Solace",
            ID = 16531,
            Level = 52,
            GCDType = GCDType.On,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell Benediction { get; } = new Spell
        {
            Name = "Benediction",
            ID = 140,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };
        
        public Spell Asylum { get; } = new Spell
        {
            Name = "Asylum",
            ID = 3569,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.TargetLocation
        };

        public Spell StoneIII { get; } = new Spell
        {
            Name = "Stone III",
            ID = 3568,
            Level = 54,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Assize { get; } = new Spell
        {
            Name = "Assize",
            ID = 3571,
            Level = 56,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };
        
        public Spell ThinAir { get; } = new Spell
        {
            Name = "Thin Air",
            ID = 7430,
            Level = 58,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
        
        public Spell Tetragrammaton { get; } = new Spell
        {
            Name = "Tetragrammaton",
            ID = 3570,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Target
        };

        public Spell StoneIV { get; } = new Spell
        {
            Name = "Stone IV",
            ID = 7431,
            Level = 64,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DivineBenison { get; } = new Spell
        {
            Name = "Divine Benison",
            ID = 7432,
            Level = 66,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell PlenaryIndulgence { get; } = new Spell
        {
            Name = "Plenary Indulgence",
            ID = 7433,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Heal,
            CastType = CastType.Self
        };
        
        public Spell Dia { get; } = new Spell
        {
            Name = "Dia",
            ID = 16532,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.DoT,
            CastType = CastType.Target
        };
        
        public Spell Glare { get; } = new Spell
        {
            Name = "Glare",
            ID = 16533,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
        
        public Spell AfflatusMisery { get; } = new Spell
        {
            Name = "Afflatus Misery",
            ID = 16535,
            Level = 74,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.TargetLocation
        };
        
        public Spell AfflatusRapture { get; } = new Spell
        {
            Name = "Afflatus Rapture",
            ID = 16534,
            Level = 76,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.TargetLocation
        };
        
        public Spell Temperance { get; } = new Spell
        {
            Name = "Temperance",
            ID = 16536,
            Level = 80,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };
    }
}