using System.Collections.Generic;
using System.Linq;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace ShinraCo
{
    public static class Managers
    {
        public static IEnumerable<BattleCharacter> DragonSight
        {
            get
            {
                return PartyMembers.Where(pm => pm.InCombat && pm.IsAlive && pm.Distance(Core.Player) < 11)
                                   .OrderByDescending(DragonSightScore);
            }
        }

        private static IEnumerable<BattleCharacter> PartyMembers
        {
            get
            {
                return PartyManager.VisibleMembers.Select(pm => pm.GameObject as BattleCharacter)
                                   .Where(pm => pm != null && pm.IsTargetable);
            }
        }

        private static int DragonSightScore(BattleCharacter c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Samurai: return 60;
                case ClassJobType.Monk: return 50;
                case ClassJobType.Ninja: return 40;
                case ClassJobType.Dragoon: return 30;
            }
            return c.IsDPS() ? 20 : c.IsTank() ? 10 : 0;
        }
    }
}
