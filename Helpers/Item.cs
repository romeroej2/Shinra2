using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public class PotionIds
        {
            public static readonly HashSet<uint> Str = new HashSet<uint>
            {
                19886, // Infusion of Strength
                22447  // Grade 2 Infusion of Strength
            };

            public static readonly HashSet<uint> Dex = new HashSet<uint>
            {
                19887, // Infusion of Dexterity
                22448  // Grade 2 Infusion of Dexterity
            };

            public static readonly HashSet<uint> Int = new HashSet<uint>
            {
                19889, // Infusion of Intelligence
                22450  // Grade 2 Infusion of Intelligence
            };

            public static readonly HashSet<uint> Mnd = new HashSet<uint>
            {
                19890, // Infusion of Mind
                22451  // Grade 2 Infusion of Mind
            };
        }

        public static async Task<bool> UsePotion(HashSet<uint> potionType)
        {
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => potionType.Contains(s.RawItemId));

            if (item == null || !item.CanUse())
            {
                return false;
            }

            item.UseItem();
            await Coroutine.Wait(1000, () => !item.CanUse());
            Logging.Write(Colors.Yellow, $@"[Shinra] Using >>> {item.Name}");
            return true;
        }
    }
}