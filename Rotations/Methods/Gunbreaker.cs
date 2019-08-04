using System.Threading.Tasks;
using System.Linq;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Gunbreaker;

namespace ShinraCo.Rotations
{
    public sealed partial class Gunbreaker
    {
        private GunbreakerSpells MySpells { get; } = new GunbreakerSpells();

        #region Pull

		private async Task<bool> LightningShot()
        {
            if (Helpers.TargetDistance(Core.Player, 3) && Core.Player.HasAura("Royal Guard"))
            {
				return await MySpells.LightningShot.Cast();
            }
            return false;
        }

        private async Task<bool> RoughDivide()
        {
            if (Helpers.TargetDistance(Core.Player,3))
            {
                return await MySpells.RoughDivide.Cast();
            }
            return false;
        }

        #endregion

        #region Single Target Damage

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

		private async Task<bool> SonicBreak()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.SonicBreak.Name))
            {
                return await MySpells.SonicBreak.Cast();
            }
            return false;
        }
		
		private async Task<bool> DangerZone()
        {
              return await MySpells.DangerZone.Cast();
        }
		
		private async Task<bool> BlastingZone()
        {
              return await MySpells.BlastingZone.Cast();
        }
		
		private async Task<bool> BurstStrike()
        {
            if (Resource.Cartridge > 0)
            {
                return await MySpells.BurstStrike.Cast();
            }
            return false;
        }
		
		#endregion
		
		#region AOE Damage

		private async Task<bool> DemonSlice()
        {
			if(Helpers.EnemiesNearPlayer(5) > 2)
			{	
				return await MySpells.DemonSlice.Cast();
			}
			return false;
        }

        private async Task<bool> DemonSlaughter()
        {
            if (ActionManager.LastSpell.Name == MySpells.DemonSlice.Name)
            {
                return await MySpells.DemonSlaughter.Cast();
            }
            return false;
        }

		private async Task<bool> FatedCircle()
        {
            if (Resource.Cartridge > 0  && ActionManager.LastSpell.Name == MySpells.DemonSlaughter.Name)
            {
                return await MySpells.FatedCircle.Cast();
            }
            return false;
        }


        private async Task<bool> BowShock()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.BowShock.Name) && Helpers.EnemiesNearPlayer(5) > 0)
            {
                return await MySpells.BowShock.Cast();
            }
            return false;
        }

        #endregion

        #region Special Combo

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
		
		private async Task<bool> Bloodfest()
        {
            if (Resource.Cartridge == 0)
            {
                return await MySpells.Bloodfest.Cast();
            }
            return false;
        }

        #endregion

        #region Buff
		
		private async Task<bool> NoMercy()
        {
            return await MySpells.NoMercy.Cast();
        }
		
		private async Task<bool> Camouflage()
        {
			if(Helpers.EnemiesNearPlayer(5) > 2)
			{	
				return await MySpells.Camouflage.Cast();
			}
			return false;
		}
		
		private async Task<bool> Nebula()
        {
			if (Helpers.EnemiesNearPlayer(5) > 5 && Core.Player.CurrentHealthPercent <= 70 && !Core.Player.HasAura(MySpells.Role.Rampart.Name))
			{	
				return await MySpells.Nebula.Cast();
			}
			return false;
		}
		
		private async Task<bool> Superbolide()
        {
			if(Core.Player.CurrentHealthPercent <= 10)
			{
				return await MySpells.Superbolide.Cast();
			}
			return false;
		}

        #endregion

        #region Heal
		
		private async Task<bool> Aurora()
        {
			var target = ShinraEx.Settings.WhiteMagePartyHeal
                ? Helpers.HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < 70)
                : Core.Player.CurrentHealthPercent < 50 ? Core.Player : null;
			if(target != null)
			{
				return await MySpells.Aurora.Cast(target);
			}				
			return false;
		}

        #endregion

        #region Role
		
		private async Task<bool> Rampart()
        {
			if(Helpers.EnemiesNearPlayer(5) > 4 && Core.Player.CurrentHealthPercent <= 70 && !Core.Player.HasAura(MySpells.Nebula.Name))
			{	
				return await MySpells.Role.Rampart.Cast();
			}
			return false;
		}

        #endregion

        #region PVP

        #endregion

        #region Custom

        #endregion
    }
}
