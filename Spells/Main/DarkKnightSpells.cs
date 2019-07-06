using ShinraCo.Spells.Role;

namespace ShinraCo.Spells.Main
{
    public class DarkKnightSpells
    {
        public TankSpells Role { get; } = new TankSpells();

        public Spell HardSlash { get; } = new Spell
        {
            Name = "Hard Slash",
            ID = 3617,
            Level = 1,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell SpinningSlash { get; } = new Spell
        {
            Name = "Spinning Slash",
            ID = 3619,
            Level = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };


        public Spell SyphonStrike { get; } = new Spell
        {
            Name = "Syphon Strike",
            ID = 3623,
            Level = 2,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Unleash { get; } = new Spell
        {
            Name = "Unleash",
            ID = 3621,
            Level = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };

        public Spell Grit { get; } = new Spell
        {
            Name = "Grit",
            ID = 3629,
            Level = 10,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell Unmend { get; } = new Spell
        {
            Name = "Unmend",
            ID = 3624,
            Level = 15,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Souleater { get; } = new Spell
        {
            Name = "Souleater",
            ID = 3632,
            Level = 26,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell FloodOfDarkness { get; } = new Spell
        {
            Name = "Flood of Darkness",
            ID = 16466,
            Level = 30,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell BloodWeapon { get; } = new Spell
        {
            Name = "Blood Weapon",
            ID = 3625,
            Level = 35,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell ShadowWall { get; } = new Spell
        {
            Name = "Shadow Wall",
            ID = 3636,
            Level = 38,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell EdgeOfDarkness { get; } = new Spell
        {
            Name = "Edge Of Darkness",
            ID = 16467,
            Level = 40,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DarkMind { get; } = new Spell
        {
            Name = "Dark Mind",
            ID = 3634,
            Level = 45,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell LivingDead { get; } = new Spell
        {
            Name = "Living Dead",
            ID = 3638,
            Level = 50,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };


        public Spell SaltedEarth { get; } = new Spell
        {
            Name = "Salted Earth",
            ID = 3639,
            Level = 52,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.TargetLocation
        };

        public Spell Plunge { get; } = new Spell
        {
            Name = "Plunge",
            ID = 3640,
            Level = 54,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell AbyssalDrain { get; } = new Spell
        {
            Name = "Abyssal Drain",
            ID = 3641,
            Level = 56,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };


        public Spell CarveAndSpit { get; } = new Spell
        {
            Name = "Carve and Spit",
            ID = 3643,
            Level = 60,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Bloodspiller { get; } = new Spell
        {
            Name = "Bloodspiller",
            ID = 7392,
            Level = 62,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Quietus { get; } = new Spell
        {
            Name = "Quietus",
            ID = 7391,
            Level = 64,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Self
        };



        public Spell Delirium { get; } = new Spell
        {
            Name = "Delirium",
            ID = 7390,
            Level = 68,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell BlackestNight { get; } = new Spell
        {
            Name = "The Blackest Night",
            ID = 7393,
            Level = 70,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell StalwartSoul { get; } = new Spell
        {
            Name = "Stalwart Soul",
            ID = 16468,
            Level = 72,
            GCDType = GCDType.On,
            SpellType = SpellType.AoE,
            CastType = CastType.Target
        };

      

        public Spell FloodOfShadow { get; } = new Spell
        {
            Name = "Flood of Shadow",
            ID = 16469,
            Level = 74,
            GCDType = GCDType.Off,
            SpellType = SpellType.AoE,
            CastType = CastType.TargetLocation
        };

        public Spell EdgeOfShadow { get; } = new Spell
        {
            Name = "Edge Of Shadow",
            ID = 16470,
            Level = 74,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell DarkMissionary { get; } = new Spell
        {
            Name = "DarkMissionary",
            ID = 16471,
            Level = 76,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell LivingShadow { get; } = new Spell
        {
            Name = "Living Shadow",
            ID = 16472,
            Level = 80,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

         

    }
}