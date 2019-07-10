using System.Threading.Tasks;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Gunbreaker;

namespace ShinraCo.Rotations
{
    public sealed partial class Gunbreaker
    {
        private GunbreakerSpells MySpells { get; } = new GunbreakerSpells();

        #region Damage

        private async Task<bool> KeenEdge()
        {
            return await MySpells.KeenEdge.Cast();
        }

        private async Task<bool> BrutalShell()
        {
            if (ActionManager.LastSpell.Name == MySpells.KeenEdge.Name)
            {
                return await MySpells.BrutalShell.Cast();
            }
            return false;
        }

        private async Task<bool> SolidBarrel()
        {
            if (ActionManager.LastSpell.Name == MySpells.BrutalShell.Name)
            {
                return await MySpells.SolidBarrel.Cast();
            }
            return false;
        }

        private async Task<bool> LightningShot()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.LightningShot.Cast();
            }
            return false;
        }

        private async Task<bool> GnashingFang()
        {
            if (Resource.Cartridge > 0)
            {
                return await MySpells.GnashingFang.Cast();
            }
            return false;
        }

        private async Task<bool> SavageClaw()
        {
            if (Resource.SecondaryComboStage == 1)
            {
                return await MySpells.SavageClaw.Cast();
            }
            return false;
        }

        private async Task<bool> WickedTalon()
        {
            if (Resource.SecondaryComboStage == 2)
            {
                return await MySpells.WickedTalon.Cast();
            }
            return false;
        }

        private async Task<bool> NoMercy()
        {
            return await MySpells.NoMercy.Cast();
        }

        private async Task<bool> SonicBreak()
        {
            if (Core.Player.HasAura("No Mercy"))
            {
                return await MySpells.SonicBreak.Cast();
            }
            return false;
        }

        private async Task<bool> BlastingZone()
        {
          if (DataManager.GetSpellData(MySpells.NoMercy.ID).Cooldown.TotalMilliseconds > 5000)
          {
              return await MySpells.BlastingZone.Cast();
          }
          return false;
        }

        private async Task<bool> DemonSlice()
        {

            return await MySpells.DemonSlice.Cast();
        }

        private async Task<bool> DemonSlaughter()
        {
            if (ActionManager.LastSpell.Name == MySpells.DemonSlice.Name)
            {
                return await MySpells.DemonSlaughter.Cast();
            }
            return false;
        }

        private async Task<bool> BurstStrike()
        {
            if ((Resource.Cartridge == 2 || (DataManager.GetSpellData(MySpells.Bloodfest.ID).Cooldown.TotalMilliseconds < 6000) && Resource.Cartridge == 1))
            {
                return await MySpells.BurstStrike.Cast();
            }
            return false;
        }

        private async Task<bool> FatedCircle()
        {
            if ((Resource.Cartridge == 2 ||
                   (DataManager.GetSpellData(MySpells.Bloodfest.ID).Cooldown.TotalMilliseconds < 6000 && Resource.Cartridge == 1) ||
                   (Resource.Cartridge > 0  && Helpers.EnemiesNearPlayer(5) > 2)) && 
                   Core.Player.TargetDistance(5, false))
            {
                return await MySpells.FatedCircle.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodfest()
        {
            if (Resource.Cartridge == 0)
            {
                return await MySpells.Bloodfest.Cast();
            }
            return false;
        }

        private async Task<bool> BowShock()
        {
            if (Core.Player.HasAura("No Mercy") && Helpers.EnemiesNearPlayer(5) > 0)
            {
                return await MySpells.BowShock.Cast();
            }
            return false;
        }


        private async Task<bool> JugularRip()
        {
            if (Core.Player.HasAura("Ready to Rip"))
            {
                return await MySpells.JugularRip.Cast();
            }
            return false;
        }

        private async Task<bool> AbdomenTear()
        {
            if (Core.Player.HasAura("Ready to Tear"))
            {
                return await MySpells.AbdomenTear.Cast();
            }
            return false;
        }

        private async Task<bool> EyeGouge()
        {
            if (Core.Player.HasAura("Ready to Gouge"))
            {
                return await MySpells.EyeGouge.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        #endregion

        #region Buff

        #endregion

        #region Heal

        #endregion

        #region Role

        #endregion

        #region PVP

        #endregion

        #region Custom

        #endregion
    }
}
