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
using Resource = ff14bot.Managers.ActionResourceManager.Dancer;

namespace ShinraCo.Rotations
{
    public sealed partial class Dancer
    {
        private DancerSpells MySpells { get; } = new DancerSpells();

        #region Damage

        private async Task<bool> Cascade()
        {
            return await MySpells.Cascade.Cast();
        }

        private async Task<bool> Fountain()
        {

            if (ActionManager.LastSpell.Name == MySpells.Cascade.Name)
            {
                return await MySpells.Fountain.Cast();
            }
            return false;
        }

        private async Task<bool> ReverseCascade()
        {
            if (Core.Player.HasAura("Flourishing Cascade"))
            {
                return await MySpells.ReverseCascade.Cast();
            }
            return false;
        }

        private async Task<bool> Fountainfall()
        {
            if (Core.Player.HasAura("Flourishing Fountain"))
            {
                return await MySpells.Fountainfall.Cast();
            }
            return false;
        }

        private async Task<bool> FanDanceI()
        {
            if ((Resource.FourFoldFeathers == 4 || Core.Player.HasAura("Devilment")))
            {
                return await MySpells.FanDanceI.Cast();
            }
            return false;
        }

        private async Task<bool> SaberDance()
        {
          if ((Core.Player.HasAura("Devilment") && Resource.Esprit >= 50) || Helpers.EnemiesNearTarget(5) > 2 || Resource.Esprit >= 100)
          {
              return await MySpells.SaberDance.Cast();
          }
          return false;
        }

        #endregion

        #region DoT


        #endregion

        #region AoE
        private async Task<bool> Windmill()
        {
            if (Helpers.EnemiesNearPlayer(5) > 1)
            {
                return await MySpells.Windmill.Cast();
            }
            return false;
        }

        private async Task<bool> Bladeshower()
        {
            if (Helpers.EnemiesNearPlayer(5) > 1 && ActionManager.LastSpell.Name == MySpells.Windmill.Name)
            {
                return await MySpells.Bladeshower.Cast();
            }
            return false;
        }

        private async Task<bool> RisingWindmill()
        {
            if (Core.Player.HasAura("Flourishing Windmill") && Core.Player.TargetDistance(5, false))
            {
                return await MySpells.RisingWindmill.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodshower()
        {
            if (Core.Player.HasAura("Flourishing Shower") && Core.Player.TargetDistance(5, false))
            {
                return await MySpells.Bloodshower.Cast();
            }
            return false;
        }

        private async Task<bool> FanDanceIII()
        {
            if (Core.Player.HasAura("Flourishing Fan Dance"))
            {
                return await MySpells.FanDanceIII.Cast();
            }
            return false;
        }

        private async Task<bool> FanDanceII()
        {
            if (((Resource.FourFoldFeathers == 4 || Core.Player.HasAura("Devilment")) && Helpers.EnemiesNearPlayer(5) > 1) || Helpers.EnemiesNearPlayer(5) > 2)
            {
                return await MySpells.FanDanceII.Cast();
            }
            return false;
        }
        #endregion

        #region Cooldown

        private async Task<bool> Emboite()
        {
            if (Resource.CurrentStep == Resource.DanceStep.Emboite)
            {
                return await MySpells.Emboite.Cast();
            }
            return false;
        }
        private async Task<bool> Jete()
        {
          if (Resource.CurrentStep == Resource.DanceStep.Jete)
          {
              return await MySpells.Jete.Cast();
          }
          return false;
        }
        private async Task<bool> Entrechat()
        {
          if (Resource.CurrentStep == Resource.DanceStep.Entrechat)
          {
              return await MySpells.Entrechat.Cast();
          }
          return false;
        }
        private async Task<bool> Pirouette()
        {
          if (Resource.CurrentStep == Resource.DanceStep.Pirouette)
          {
              return await MySpells.Pirouette.Cast();
          }
          return false;
        }


        private async Task<bool> StandardStep()
        {
            if (!Core.Player.HasAura(MySpells.StandardFinish.Name) || IsCurrentBuffExpired()==true)
            {
                if (await MySpells.StandardStep.Cast())
                {
                    SetCurrentBuffTimer(TimeSpan.FromSeconds(55));
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> StandardFinish()
        {
          if (Resource.CurrentStep == Resource.DanceStep.Finish && Core.Player.Distance(Core.Player.CurrentTarget) <= 15)
          {
                return await MySpells.StandardFinish.Cast();
          }
          return false;
        }

        private async Task<bool> TechnicalStep()
        {
            return await MySpells.TechnicalStep.Cast();
        }

        private async Task<bool> TechnicalFinish()
        {
          if (Resource.CurrentStep == Resource.DanceStep.Finish && Core.Player.Distance(Core.Player.CurrentTarget) <= 15)
          {
              return await MySpells.TechnicalFinish.Cast();
          }
          return false;
        }

        #endregion

        #region Buff

        private async Task<bool> Devilment()
        {
            return await MySpells.Devilment.Cast();
        }

        private async Task<bool> Flourish()
        {
            return await MySpells.Flourish.Cast();
        }

        #endregion

        #region Heal

        private async Task<bool> CuringWaltz()
        {
            if (Core.Player.CurrentHealthPercent < 70)
            {
                return await MySpells.CuringWaltz.Cast();
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (Core.Player.CurrentHealthPercent < 30)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        #endregion

        #region PVP

        #endregion

        #region Custom

        public static DateTime CurrentBuffExpireTime { get; set; }

        private void SetCurrentBuffTimer(TimeSpan duration)
        {
            CurrentBuffExpireTime = DateTime.UtcNow + duration;
        }

        public bool IsCurrentBuffExpired()
        {
            return DateTime.UtcNow > CurrentBuffExpireTime;
        }

        #endregion
    }
}
