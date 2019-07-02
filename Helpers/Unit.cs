using System;
using System.Collections.Generic;
using System.Linq;
using Clio.Common;
using Clio.Utilities;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static bool InView(Vector3 playerLocation, float playerHeading, Vector3 targetLocation)
        {
            var d = Math.Abs(MathEx.NormalizeRadian(playerHeading -
                    MathEx.NormalizeRadian(MathHelper.CalculateHeading(playerLocation, targetLocation) +
                    (float)Math.PI)));

            if (d > Math.PI) d = Math.Abs(d - 2 * (float)Math.PI);
            return d < 0.78539f;
        }

        public static bool TargetDistance(this LocalPlayer cp, float range, bool useMinRange = true)
        {
            return useMinRange ? cp.HasTarget && cp.Distance2D(cp.CurrentTarget) - cp.CombatReach - cp.CurrentTarget.CombatReach >= range
                : cp.HasTarget && cp.Distance2D(cp.CurrentTarget) - cp.CombatReach - cp.CurrentTarget.CombatReach <= range;
        }

        private static bool UnitDistance(this LocalPlayer cp, GameObject unit, float range, bool useMinRange = true)
        {
            return useMinRange ? cp.Distance2D(unit) - cp.CombatReach - unit.CombatReach >= range
                : cp.Distance2D(unit) - cp.CombatReach - unit.CombatReach <= range;
        }

        private static bool ValidEnemy(this GameObject unit)
        {
            if (unit == null || !unit.IsValid || !unit.CanAttack || !unit.IsTargetable)
                return false;

            if (!GameObjectManager.Attackers.Contains(unit) && Core.Me.Distance2D(unit) > 25)
                return false;

            return unit.CurrentHealth > 0;
        }

        public static IEnumerable<BattleCharacter> Enemies
        {
            get { return GameObjectManager.GetObjectsOfType<BattleCharacter>(true).Where(eu => eu.ValidEnemy()); }
        }

        public static int EnemiesNearTarget(int range)
        {
            if (Core.Me.CurrentTarget == null)
                return 0;

            return Enemies.Count(u =>
                u.Distance2D(Core.Player.CurrentTarget) - Math.Max(u.CombatReach, Core.Player.CurrentTarget.CombatReach) <= range);
        }

        public static int EnemiesNearPlayer(float radius)
        {
            return Enemies.Count(eu => eu.Distance2D(Core.Player) - eu.CombatReach - Core.Player.CombatReach <= radius);
        }
    }
}