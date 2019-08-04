using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Machinist;

namespace ShinraCo.Rotations
{
    public sealed partial class Machinist
    {
        private MachinistSpells MySpells { get; } = new MachinistSpells();

        #region Damage

        private async Task<bool> SplitShot()
        {
			return await MySpells.SplitShot.Cast();

        }

        private async Task<bool> SlugShot()
        {
            if (ActionManager.LastSpell.Name == MySpells.SplitShot.Name)
			{
				return await MySpells.SlugShot.Cast();
			}
			return false;
        }

        private async Task<bool> CleanShot()
        {
            if (ActionManager.LastSpell.Name == MySpells.SlugShot.Name)
			{
				return await MySpells.CleanShot.Cast();
			}
			return false;
        }

        public async Task<bool> HotShot()
        {
			return await MySpells.HotShot.Cast();
		}
		
		public async Task<bool> Drill()
        {
			return await MySpells.Drill.Cast();
		}
		
		public async Task<bool> HeatBlast()
        {
            return await MySpells.Heatblast.Cast();
        }

        #endregion

        #region AoE

        private async Task<bool> SpreadShot()
        {
            if (Helpers.EnemiesNearTarget(5) >= AoECount)
            {
                return await MySpells.SpreadShot.Cast();
            }
            return false;
        }
		
		private async Task<bool> Crossbow()
        {
            if (Helpers.EnemiesNearTarget(5) >= AoECount)
            {
                return await MySpells.Crossbow.Cast();
            }
            return false;
        }
		
		private async Task<bool> Bioblaster()
        {
            if (Helpers.EnemiesNearTarget(5) >= AoECount && !MovementManager.IsMoving)
            {
                    if (await MySpells.Bioblaster.Cast())
                    {
                        return await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Bioblaster.Name));
                    }
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> Wildfire()
        {
            if(Helpers.EnemiesNearTarget(5) < AoECount && (!Core.Player.CurrentTarget.HasAura(MySpells.Wildfire.Name, true) || Core.Player.CurrentTarget.CurrentHealthPercent <= 5))
			{
				return await MySpells.Wildfire.Cast();
			}
			return false;
        }

        private async Task<bool> GaussRound()
        {
			if(WildfireCooldown >= 30000)
			{
				return await MySpells.GaussRound.Cast();
			}
			return false;
        }

        private async Task<bool> Ricochet()
        {
			if(WildfireCooldown >= 30000)
			{
				return await MySpells.Ricochet.Cast();
			}
			return false;
        }

        private async Task<bool> Flamethrower()
        {
            if (!MovementManager.IsMoving)
            {
                    if (await MySpells.Flamethrower.Cast())
                    {
                        return await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.Flamethrower.Name));
                    }
            }
            return false;
        }

        #endregion

        #region Buff
		
		public async Task<bool> Reassemble()
		{
				return await MySpells.Reassemble.Cast();
		}
		
        private async Task<bool> Hypercharge()
        {
            if (Resource.Heat >= 50)
            {
                return await MySpells.Hypercharge.Cast();
            }
            return false;
        }

        private async Task<bool> BarrelStabilizer()
        {
                if (Resource.Heat <=  50)
                {
                    return await MySpells.BarrelStabilizer.Cast();
                }

            return false;
        }

        private async Task<bool> RookOverdrive()
        {
			if (IsCurrentFormExpired())
                {
					return await MySpells.RookOverdrive.Cast();	
                }
            return false;
        }

        #endregion

        #region Turret

        private async Task<bool> RookAutoturret()
        {
			if (Resource.Battery == 100)
			{
				if(await MySpells.RookAutoturret.Cast())
				{
					SetCurrentFormTimer(TimeSpan.FromSeconds(Resource.Battery * 2 / 10));
					return true;
				}
               
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (Core.Player.CurrentHealthPercent < 20)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }
		
		 public async Task<bool> Peloton()
        {
            if (!Core.Player.HasAura(MySpells.Role.Peloton.Name) && !Core.Player.HasTarget &&
                (MovementManager.IsMoving || BotManager.Current.EnglishName == "DeepDive"))
            {
                return await MySpells.Role.Peloton.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static int AoECount => ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 3;
        private static double HyperchargeCooldown => DataManager.GetSpellData(17209).Cooldown.TotalMilliseconds;
        private static double WildfireCooldown => DataManager.GetSpellData(2878).Cooldown.TotalMilliseconds;

        public static DateTime CurrentFormExpireTime { get; set; }

        private void SetCurrentFormTimer(TimeSpan duration)
        {
            CurrentFormExpireTime = DateTime.UtcNow + duration;
        }

        public bool IsCurrentFormExpired()
        {
            return DateTime.UtcNow > CurrentFormExpireTime;
        }

        #endregion
    }
}