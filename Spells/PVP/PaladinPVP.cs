namespace ShinraCo.Spells.PVP
{
    public class PaladinPVP
    {
        public Spell RageOfHalone { get; } = new Spell
        {
            Name = "Rage of Halone",
            ID = 8748,
            Combo = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell RoyalAuthority { get; } = new Spell
        {
            Name = "Royal Authority",
            ID = 8750,
            Combo = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell HolySpirit { get; } = new Spell
        {
            Name = "Holy Spirit",
            ID = 8752,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Requiescat { get; } = new Spell
        {
            Name = "Requiescat",
            ID = 8754,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}