using System.Collections.Generic;
using ShinraCo.Spells.Main;

namespace ShinraCo.Spells.Opener
{
    public class DarkKnightOpener
    {
        private static DarkKnightSpells Spells { get; } = new DarkKnightSpells();

        public static List<Spell> List = new List<Spell>
        {
            Spells.HardSlash,
           
            Spells.SyphonStrike,
            Spells.Souleater,
            Spells.SaltedEarth,
            Spells.BloodWeapon,
            Spells.HardSlash,
          
            Spells.SyphonStrike,
           
            Spells.Delirium,
            Spells.Souleater,
            Spells.Plunge,
            
            Spells.HardSlash,
            Spells.CarveAndSpit,
     
            Spells.SyphonStrike,
   
            Spells.Bloodspiller
        };
    }
}
