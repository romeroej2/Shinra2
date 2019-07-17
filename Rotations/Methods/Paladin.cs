using System.Threading.Tasks;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Paladin;

namespace ShinraCo.Rotations
{
    public sealed partial class Paladin
    {
        private PaladinSpells MySpells { get; } = new PaladinSpells();

        #region Damage

        private async Task<bool> FastBlade()
        {
            return await MySpells.FastBlade.Cast();
        }

        private async Task<bool> RiotBlade()
        {
            if (ActionManager.LastSpell.Name == MySpells.FastBlade.Name)
            {
                return await MySpells.RiotBlade.Cast();
            }
            return false;
        }

        private async Task<bool> GoringBlade()
        {
            if (ActionManager.LastSpell.Name == MySpells.RiotBlade.Name &&
                !Core.Player.CurrentTarget.HasAura(725, true, 2100))
            {
                return await MySpells.GoringBlade.Cast();
            }
            return false;
        }

        private async Task<bool> RoyalAuthority()
        {
            if (ActionManager.LastSpell.Name == MySpells.RiotBlade.Name)
            {
                return await MySpells.RoyalAuthority.Cast();
            }
            return false;
        }

        private async Task<bool> RageOfHalone()
        {
            if (ActionManager.LastSpell.Name == MySpells.RiotBlade.Name)
            {
                return await MySpells.RageOfHalone.Cast();
            }
            return false;
        }
        
        private async Task<bool> HolySpirit()
        {
            if (!MovementManager.IsMoving &&
                (ShinraEx.LastSpell.Name == MySpells.Requiescat.Name ||
                Core.Player.HasAura(1368, true, 1200)))
            {
                return await MySpells.HolySpirit.Cast();
            }
            return false;
        }
        
        private async Task<bool> Atonement()
        {
            if (ActionManager.LastSpell.Name == MySpells.RoyalAuthority.Name || 
                Core.Player.HasAura(1902, true))
            {
                return await MySpells.Atonement.Cast();
            }
            return false;
        }
        
        private async Task<bool> Confiteor()
        {
            if (ShinraEx.LastSpell.Name == MySpells.Requiescat.Name ||
                Core.Player.HasAura(1368, true, 1200))
            {
                return await MySpells.Confiteor.Cast();
            }
            return false;
        }
        
        private async Task<bool> ShieldLob()
        {
            if (Core.Player.TargetDistance(10) && ShinraEx.Settings.TankMode == TankModes.Enmity)
            {
                return await MySpells.ShieldLob.Cast();
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> TotalEclipse()
        {
            var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 5;
            
            if (ShinraEx.Settings.PaladinTotalEclipse && Helpers.EnemiesNearTarget(5) >= count)
            {
                return await MySpells.TotalEclipse.Cast();
            }
            return false;
        }

        private async Task<bool> Prominence()
        {
            var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 5;
            
            if (ShinraEx.Settings.PaladinProminence && Core.Player.CurrentManaPercent < 30 && Helpers.EnemiesNearTarget(5) >= count)
            {
                return await MySpells.Prominence.Cast();
            }
            return false;
        }
        
        private async Task<bool> HolyCircle()
        {
            var count = ShinraEx.Settings.CustomAoE ? ShinraEx.Settings.CustomAoECount : 5;
            
            if (ShinraEx.Settings.PaladinHolyCircle && Core.Player.CurrentManaPercent < 20 && Helpers.EnemiesNearTarget(5) >= count)
            {
                return await MySpells.HolyCircle.Cast();
            }
            return false;
        }
        
        #endregion

        #region Cooldown
        private async Task<bool> SpiritsWithin()
        {
            if (ShinraEx.Settings.PaladinSpiritsWithin && ShinraEx.LastSpell.Name != MySpells.CircleOfScorn.Name)
            {
                return await MySpells.SpiritsWithin.Cast();
            }
            return false;
        }

        private async Task<bool> CircleOfScorn()
        {
            if (ShinraEx.Settings.PaladinCircleOfScorn && ShinraEx.LastSpell.Name != MySpells.SpiritsWithin.Name)
            {
                if (Core.Player.TargetDistance(5, false))
                {
                    return await MySpells.CircleOfScorn.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Requiescat()
        {
            if (!ShinraEx.Settings.PaladinRequiescat || !Core.Player.CurrentTarget.HasAura(725, true) ||
                MovementManager.IsMoving || Core.Player.CurrentManaPercent < 80 || ShinraEx.LastSpell.Name == MySpells.FightOrFlight.Name ||
                Core.Player.HasAura(76, true))
            {
                return false;
            }

            var gcd = DataManager.GetSpellData(9).Cooldown.TotalMilliseconds;

            if (gcd == 0 || gcd > 500) return false;

            return await MySpells.Requiescat.Cast(null, false);
        }

        #endregion

        #region Buff

        private async Task<bool> IronWill()
        {
            if (ShinraEx.Settings.TankMode == TankModes.DPS && Core.Player.HasAura(79, true))
            {
                return false;
            }

            return await MySpells.IronWill.Cast();
        }
        
        private async Task<bool> FightOrFlight()
        {
            if (!ShinraEx.Settings.PaladinFightOrFlight || ShinraEx.LastSpell.Name == MySpells.Requiescat.Name ||
                Core.Player.HasAura(1368, true) || !Core.Player.TargetDistance(5, false))
            {
                return false;
            }

            return await MySpells.FightOrFlight.Cast();
        }

        private async Task<bool> Sentinel()
        {
            if (ShinraEx.Settings.PaladinSentinel && Core.Player.CurrentHealthPercent < ShinraEx.Settings.PaladinSentinelPct)
            {
                return await MySpells.Sentinel.Cast();
            }
            return false;
        }

        private async Task<bool> HallowedGround()
        {
            if (ShinraEx.Settings.PaladinHallowedGround && Core.Player.CurrentHealthPercent < ShinraEx.Settings.PaladinHallowedGroundPct)
            {
                return await MySpells.HallowedGround.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Sheltron()
        {
            if (ShinraEx.Settings.PaladinSheltron && !Core.Player.HasAura(728, true))
            {
                if (OathValue == 100 || OathValue > 50)
                {
                    return await MySpells.Sheltron.Cast();
                }
            }
            return false;
        }

        private async Task<bool> PassageOfArms()
        {
            // Core.Player.HasAura(1175, true, 18000)
            return false;
        }

        #endregion

        #region Heal

        private async Task<bool> Clemency()
        {
            if (ShinraEx.Settings.PaladinClemency && Core.Player.CurrentHealthPercent < ShinraEx.Settings.PaladinClemencyPct)
            {
                if (Core.Player.CurrentManaPercent > 40 && !MovementManager.IsMoving)
                {
                    if (Core.Player != null)
                    {
                        return await MySpells.Clemency.Cast(Core.Player);
                    }
                }
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> Rampart()
        {
            if (ShinraEx.Settings.PaladinRampart && Core.Player.CurrentHealthPercent < ShinraEx.Settings.PaladinRampartPct)
            {
                return await MySpells.Role.Rampart.Cast();
            }
            return false;
        }

        private async Task<bool> LowBlow()
        {
            if (ShinraEx.Settings.PaladinLowBlow && (Core.Player.CurrentTarget.IsInterruptible() ||
                                                     Core.Player.CurrentTarget.IsInterruptibleSpell()))
            {
                return await MySpells.Role.LowBlow.Cast();
            }
            return false;
        }
        
        private async Task<bool> Provoke()
        {
            if (ShinraEx.Settings.PaladinProvoke)
            {
                return await MySpells.Role.Provoke.Cast();
            }
            return false;
        }
        
        private async Task<bool> Interject()
        {
            if (ShinraEx.Settings.PaladinInterject && (Core.Player.CurrentTarget.IsInterruptible() || 
                                                       Core.Player.CurrentTarget.IsInterruptibleSpell()))
            {
                return await MySpells.Role.Interject.Cast();
            }
            return false;
        }
        
        private async Task<bool> Reprisal()
        {
            if (ShinraEx.Settings.PaladinReprisal)
            {
                return await MySpells.Role.Reprisal.Cast();
            }
            return false;
        }
        
        private async Task<bool> ArmsLength()
        {
            if (ShinraEx.Settings.PaladinArmsLength)
            {
                return await MySpells.Role.ArmsLength.Cast();
            }
            return false;
        }
        
        #endregion

        #region PVP

        private async Task<bool> RageOfHalonePVP()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.RageOfHalone.Name, false, 8000) &&
                ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.RoyalAuthority.Combo) != MySpells.PVP.RoyalAuthority.ID)
            {
                return await MySpells.PVP.RageOfHalone.Cast();
            }
            return false;
        }

        private async Task<bool> RoyalAuthorityPVP()
        {
            return await MySpells.PVP.RoyalAuthority.Cast();
        }

        private async Task<bool> HolySpiritPVP()
        {
            if (!MovementManager.IsMoving && Core.Player.HasAura(MySpells.Requiescat.Name))
            {
                return await MySpells.PVP.HolySpirit.Cast();
            }
            return false;
        }

        private async Task<bool> RequiescatPVP()
        {
            if (!MovementManager.IsMoving)
            {
                return await MySpells.PVP.Requiescat.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static int OathValue => Resource.Oath;

        #endregion
    }
}
