using System;
using System.Linq;
using System.Threading.Tasks;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Monk;

namespace ShinraCo.Rotations
{
    public sealed partial class Monk
    {
        private MonkSpells MySpells { get; } = new MonkSpells();

        #region Damage

        private async Task<bool> Bootshine()
        {
            return await MySpells.Bootshine.Cast();
        }

        private async Task<bool> TrueStrike()
        {
            if (RaptorForm || BalanceActive)
            {
                return await MySpells.TrueStrike.Cast();
            }
            return false;
        }

        private async Task<bool> SnapPunch()
        {
            if (CoeurlForm || BalanceActive && (Resource.GreasedLightning < 3 || Resource.Timer < TimeSpan.FromMilliseconds(6000)))
            {
                return await MySpells.SnapPunch.Cast();
            }
            return false;
        }

        private async Task<bool> TwinSnakes()
        {
            if ((RaptorForm || BalanceActive) && !Core.Player.HasAura(MySpells.TwinSnakes.Name, true, 6000))
            {
                return await MySpells.TwinSnakes.Cast();
            }
            return false;
        }

        private async Task<bool> DragonKick()
        {
            if ((OpoOpoForm || BalanceActive) && !Core.Player.CurrentTarget.HasAura(821, false, 6000))
            {
                return await MySpells.DragonKick.Cast();
            }
            return false;
        }

        #endregion

        #region DoT

        private async Task<bool> Demolish()
        {
            if (ShinraEx.Settings.MonkDemolish && (Core.Player.CurrentTarget.IsBoss() ||
                                                 Core.Player.CurrentTarget.CurrentHealth > ShinraEx.Settings.MonkDemolishHP))
            {
                if ((CoeurlForm || BalanceActive) && !Core.Player.CurrentTarget.HasAura(MySpells.Demolish.Name, true, 6000))
                {
                    return await MySpells.Demolish.Cast();
                }
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> Rockbreaker()
        {
            if (CoeurlForm || BalanceActive && Core.Player.HasAura(MySpells.TwinSnakes.Name))
            {
                return await MySpells.Rockbreaker.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> ShoulderTackle()
        {
            if (ShinraEx.Settings.MonkShoulderTackle && Core.Player.TargetDistance(10))
            {
                return await MySpells.ShoulderTackle.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> SteelPeak()
        {
            if (ShinraEx.Settings.MonkSteelPeak)
            {
                return await MySpells.SteelPeak.Cast();
            }
            return false;
        }

        private async Task<bool> HowlingFist()
        {
            if (ShinraEx.Settings.MonkHowlingFist)
            {
                return await MySpells.HowlingFist.Cast();
            }
            return false;
        }

        private async Task<bool> ForbiddenChakra()
        {
            if (ShinraEx.Settings.MonkForbiddenChakra && Resource.FithChakra == 5)
            {
                return await MySpells.ForbiddenChakra.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> ElixirField()
        {
            if (ShinraEx.Settings.MonkElixirField && Core.Player.TargetDistance(5, false))
            {
                return await MySpells.ElixirField.Cast();
            }
            return false;
        }

        private async Task<bool> FireTackle()
        {
            if (ShinraEx.Settings.MonkFireTackle && Core.Player.TargetDistance(10))
            {
                return await MySpells.FireTackle.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> InternalRelease()
        {
            if (ShinraEx.Settings.MonkInternalRelease)
            {
                return await MySpells.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> PerfectBalance()
        {
            if (ShinraEx.Settings.MonkPerfectBalance)
            {
                return await MySpells.PerfectBalance.Cast();
            }
            return false;
        }

        private async Task<bool> FormShift()
        {
            if (!ShinraEx.Settings.MonkFormShift || !Core.Player.HasTarget || CoeurlForm) return false;

            return await MySpells.FormShift.Cast();
        }

        private async Task<bool> Meditation()
        {
            if (!ShinraEx.Settings.MonkMeditation || Resource.FithChakra == 5) return false;

            return await MySpells.Meditation.Cast();
        }

        private async Task<bool> RiddleOfFire()
        {
            if (ShinraEx.Settings.MonkRiddleOfFire)
            {
                return await MySpells.RiddleOfFire.Cast();
            }
            return false;
        }

        private async Task<bool> Brotherhood()
        {
            if (ShinraEx.Settings.MonkBrotherhood)
            {
                return await MySpells.Brotherhood.Cast();
            }
            return false;
        }

        #endregion

        #region Fists

        private async Task<bool> FistsOfEarth()
        {
            if (ShinraEx.Settings.MonkFist == MonkFists.Earth ||
                ShinraEx.Settings.MonkFist == MonkFists.Wind && !ActionManager.HasSpell(MySpells.FistsOfWind.Name) ||
                ShinraEx.Settings.MonkFist == MonkFists.Fire && !ActionManager.HasSpell(MySpells.FistsOfFire.Name))
            {
                if (!Core.Player.HasAura(MySpells.FistsOfEarth.Name))
                {
                    return await MySpells.FistsOfEarth.Cast(null, false);
                }
            }
            return false;
        }

        private async Task<bool> FistsOfWind()
        {
            if (ShinraEx.Settings.MonkFist == MonkFists.Wind && !Core.Player.HasAura(MySpells.FistsOfWind.Name) &&
                !Core.Player.HasAura(MySpells.RiddleOfEarth.Name))
            {
                return await MySpells.FistsOfWind.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> FistsOfFire()
        {
            if (ShinraEx.Settings.MonkFist == MonkFists.Fire && !Core.Player.HasAura(MySpells.FistsOfFire.Name) &&
                !Core.Player.HasAura(MySpells.RiddleOfEarth.Name))
            {
                return await MySpells.FistsOfFire.Cast(null, false);
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> SecondWind()
        {
            if (ShinraEx.Settings.MonkSecondWind && Core.Player.CurrentHealthPercent < ShinraEx.Settings.MonkSecondWindPct)
            {
                return await MySpells.Role.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (ShinraEx.Settings.MonkInvigorate && Core.Player.CurrentTPPercent < ShinraEx.Settings.MonkInvigoratePct)
            {
                return await MySpells.Role.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (ShinraEx.Settings.MonkBloodbath && Core.Player.CurrentHealthPercent < ShinraEx.Settings.MonkBloodbathPct)
            {
                return await MySpells.Role.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (ShinraEx.Settings.MonkGoad)
            {
                var target = Helpers.GoadManager.FirstOrDefault(gm => gm.CurrentTPPercent < ShinraEx.Settings.MonkGoadPct);

                if (target != null)
                {
                    return await MySpells.Role.Goad.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> TrueNorth()
        {
            if (ShinraEx.Settings.MonkTrueNorth && Core.Player.TargetDistance(5, false))
            {
                return await MySpells.Role.TrueNorth.Cast();
            }
            return false;
        }

        #endregion

        #region PVP

        private async Task<bool> SnapPunchPVP()
        {
            return await MySpells.PVP.SnapPunch.Cast();
        }

        private async Task<bool> DemolishPVP()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Demolish.Name, true, 6000) &&
                ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Bootshine.Combo) == MySpells.PVP.Bootshine.ID)
            {
                return await MySpells.PVP.Demolish.Cast();
            }
            return false;
        }

        private async Task<bool> SomersaultPVP()
        {
            if (Core.Player.CurrentTP > 700 && Resource.FithChakra < 5)
            {
                return await MySpells.PVP.Somersault.Cast();
            }
            return false;
        }

        private async Task<bool> TheForbiddenChakraPVP()
        {
            if (Resource.FithChakra == 5)
            {
                return await MySpells.PVP.TheForbiddenChakra.Cast();
            }
            return false;
        }

        private async Task<bool> FormShiftPVP()
        {
            if (Resource.GreasedLightning < 3 || Resource.Timer.TotalMilliseconds < 2000)
            {
                return await MySpells.PVP.FormShift.Cast();
            }
            return false;
        }

        private async Task<bool> TornadoKickPVP()
        {
            if (Resource.GreasedLightning == 3 && Core.Player.CurrentTarget.CurrentHealthPercent < 20)
            {
                if (ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.SnapPunch.Combo) == MySpells.PVP.SnapPunch.ID ||
                    ActionManager.GetPvPComboCurrentActionId(MySpells.PVP.Demolish.Combo) == MySpells.PVP.Demolish.ID)
                {
                    return await MySpells.PVP.TornadoKick.Cast();
                }
            }
            return false;
        }

        private async Task<bool> RiddleOfFirePVP()
        {
            if ((Resource.FithChakra >= 4 || Resource.GreasedLightning == 3) && Core.Player.TargetDistance(5, false))
            {
                return await MySpells.PVP.RiddleOfFire.Cast();
            }
            return false;
        }

        #endregion

        #region Custom

        private static bool OpoOpoForm => Core.Player.HasAura(107);
        private static bool RaptorForm => Core.Player.HasAura(108);
        private static bool CoeurlForm => Core.Player.HasAura(109);
        private static bool BalanceActive => Core.Player.HasAura(110);

        #endregion
    }
}