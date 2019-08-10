using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace ShinraCo
{
    public static partial class Helpers
    {
        internal class PotionIds
        {
            public static readonly HashSet<uint> Vit = new HashSet<uint>
            {
                19888, // Infusion of Vitality
                22449, // Grade 2 Infusion of Vitality
                24263,  // Grade 3 Infusion of Vitality
                27788,  //Tincture
                27997   //grade 2 tincture

            };
            
            public static readonly HashSet<uint> Str = new HashSet<uint>
            {
                19886, // Infusion of Strength
                22447, // Grade 2 Infusion of Strength
                24261,  // Grade 3 Infusion of Strength
                27786,  //Tincture
                27995   //grade 2 tincture

            };

            public static readonly HashSet<uint> Dex = new HashSet<uint>
            {
                19887, // Infusion of Dexterity
                22448, // Grade 2 Infusion of Dexterity
                24262,  // Grade 3 Infusion of Dexterity
                27787,  //Tincture
                27996   //grade 2 tincture
            };

            public static readonly HashSet<uint> Int = new HashSet<uint>
            {
                19889, // Infusion of Intelligence
                22450, // Grade 2 Infusion of Intelligence
                24264,  // Grade 3 Infusion of Intelligence
                27789,  //Tincture
                27998   //grade 2 tincture
            };

            public static readonly HashSet<uint> Mnd = new HashSet<uint>
            {
                19890, // Infusion of Mind
                22451, // Grade 2 Infusion of Mind
                24265,  // Grade 3 Infusion of Mind
                27790,  //Tincture
                27999   //grade 2 tincture
            };


            public static readonly List<uint> Health = new List<uint>
            {
                
                23167,  //Super Potion
                4554,  //X-Potion
                13637, // Max-Potion
                4552,  // Hi-Potion
                4551,  // Potion
            };
        }

        internal static async Task<bool> UsePotion(ICollection<uint> potionType)
        {
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => potionType.Contains(s.RawItemId));

            if (item == null || !item.CanUse()) return false;

            item.UseItem();
            await Coroutine.Wait(1000, () => !item.CanUse());
            Logging.Write(Colors.Yellow, $@"[ShinraEx] Using >>> {item.Name}");
            return true;
        }


        internal static async Task<bool> UseHealthPotion()
        {
            if (ShinraEx.Settings.UseHealthPotion)
            {
                if (Core.Player.CurrentHealthPercent < 15)
                {
                    Logging.Write(Colors.Yellow, "[ShinraEx] Try to use Potion");
                    BagSlot item = null;
                    foreach (var potionId in Helpers.PotionIds.Health)
                    {
                        item = InventoryManager.FilledSlots.FirstOrDefault(s => potionId == s.RawItemId);
                        if (item != null || item.CanUse())
                        {
                            Logging.Write(Colors.Yellow, $@"[ShinraEx] Trying to use >>> {item.Name}");
                            break;
                            

                        }
                    }


                    item.UseItem();
                    await Coroutine.Wait(1000, () => !item.CanUse());
                    Logging.Write(Colors.Yellow, $@"[ShinraEx] Using >>> {item.Name}");
                    return true;
                }
            }
            return false;
        }

       
    }
}