using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static List<BattleCharacter> HealManager = new List<BattleCharacter>(), 
                                            RessManager = new List<BattleCharacter>(),
                                            GoadManager = new List<BattleCharacter>();

        public static readonly HashSet<string> HealingSpells = new HashSet<string>
        {
            "Benefic", "Benefic II", "Helios", "Aspected Helios", "Ascend",
            "Cure", "Cure II", "Cure III", "Medica", "Medica II", "Afflatus Rapture", "Afflatus Solace", "Raise",
            "Physick", "Adloquium", "Succor", "Resurrection", "Esuna"
        };

        private static IEnumerable<BattleCharacter> PartyMembers
        {
            get
            {
                return PartyManager.VisibleMembers.Select(pm => pm.GameObject as BattleCharacter)
                                   .Where(pm => pm != null && pm.IsHealable());
            }
        }

        public static int FriendsNearPlayer(int hp, float radius = 15)
        {
            /*
            foreach (var hm in HealManager)
            {
                Logging.Write(Colors.Yellow, $@"[ShinraEx] PM {hm.Name} >>> {hm.Distance2D(Core.Player) - hm.CombatReach - Core.Player.CombatReach}");
            }*/

            return HealManager.Count(hm => hm.CurrentHealthPercent < hp &&
                                           hm.Distance2D(Core.Player) - hm.CombatReach - Core.Player.CombatReach <= radius);
        }

        private static bool IsHealable(this GameObject c)
        {
            return c.IsTargetable && c.InLineOfSight() && Core.Player.UnitDistance(c, 25, false);
        }

        public static async Task<bool> UpdateHealManager()
        {
            var healList = new List<BattleCharacter>();
         
            if (PartyManager.IsInParty)
            {
                healList.AddRange(PartyMembers.Where(pm => pm.IsAlive));
                RessManager = new List<BattleCharacter>();
                RessManager.AddRange(PartyMembers.Where(pm => pm.IsDead));
            }
            else
            {
                healList.Add(Core.Player);
                RessManager = new List<BattleCharacter>();
            }
            //if (Core.Player.Pet != null && (int)PetManager.ActivePetType < 10)
            //{
            //    healList.Add(Core.Player.Pet);
            //}
            if (ChocoboManager.Object != null)
            {
                healList.Add(ChocoboManager.Object);
            }
            HealManager = healList.OrderBy(HPScore).ToList();

            /*
            foreach (var hm in Helpers.HealManager)
            {
                Logging.Write(Colors.Yellow, $@"[ShinraEx] PM {hm.Name} >>> {hm.CurrentHealthPercent}");
            }

            foreach (var hm in Helpers.RessManager)
            {
                Logging.Write(Colors.Yellow, $@"[ShinraEx] RS {hm.Name} >>> {hm.CurrentHealthPercent}");
            }*/

            return true;
        }

        public static async Task UpdateParty()
        {
            var partyList = new List<BattleCharacter>();
            var goadList = new List<BattleCharacter>();
            if (PartyManager.IsInParty)
            {
                partyList.AddRange(PartyMembers.Where(pm => pm.IsAlive && pm.InCombat));
                goadList.AddRange(PartyMembers.Where(pm => pm.IsAlive && pm.InCombat && pm != Core.Player &&
                                                           !ManaJobs.Contains(pm.CurrentJob)));
            }
            else
            {
                partyList.Add(Core.Player);
            }
            HealManager = partyList.OrderBy(HPScore).ToList();
            GoadManager = goadList.OrderBy(TPScore).ToList();
        }

        private static float HPScore(BattleCharacter c)
        {
            var score = c.CurrentHealthPercent;

            if (c.IsTank()) score -= 5f;
            if (c.IsHealer()) score -= 3f;
            return score;
        }

        private static float TPScore(BattleCharacter c)
        {
            var score = c.CurrentTPPercent;

            if (c.IsDPS()) score -= 10;
            return score;
        }

        public static bool IsTank(this Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.DarkKnight:
                case ClassJobType.Gladiator:
                case ClassJobType.Marauder:
                case ClassJobType.Paladin:
                case ClassJobType.Warrior:
				case ClassJobType.Gunbreaker:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsHealer(this Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Arcanist:
                case ClassJobType.Astrologian:
                case ClassJobType.Conjurer:
                case ClassJobType.Scholar:
                case ClassJobType.WhiteMage:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsDPS(this Character c)
        {
            return !c.IsTank() && !c.IsHealer();
        }
    }
}